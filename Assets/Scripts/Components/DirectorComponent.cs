using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
namespace BehaviorTreeAIExample
{
    // メタAI
    public class DirectorComponent : BehaviourTreeExampleBehaviour
    {
        readonly int CanvasSizeX = 640;
        readonly int CanvasSizeY = 1136;

        void Update()
        {
            AddFood();
            AddCharactor();
        }

        void AddFood()
        {
            // マップ上のFoodが足りなくなったら配置する。
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            if (foods.Length < 3)
            {
                var position = new Vector2();
                InstantiateChild("", position, gameObject.transform);

                var child = Instantiate(Resources.Load(""), transform.position, transform.rotation) as GameObject;
                child.transform.SetParent(transform, false);
                child.transform.localPosition = position;
            }

        }

        // マップ上のCharactorがいなかったら（いなくなったら）配置する。
        void AddCharactor()
        {
            GameObject[] charactors = GameObject.FindGameObjectsWithTag("Charactor");

            if (charactors.Length == 0)
                InstantiateChild("Charactor", new Vector2(0, 0), gameObject.transform);
        }

    }
}