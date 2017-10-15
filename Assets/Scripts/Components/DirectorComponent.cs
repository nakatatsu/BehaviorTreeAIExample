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
            var random = new System.Random();

            // マップ上のFoodが足りなくなったら配置する。
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            if (foods.Length < 1)
            {
                int x = random.Next(-CanvasSizeX / 2, CanvasSizeX / 2);
                int y = random.Next(-CanvasSizeY / 2, CanvasSizeY / 2);
                var newFood = InstantiateChild("Food", new Vector2(x, y), gameObject.transform);
                var foodComponent = newFood.AddComponent<FoodComponent>();

                foodComponent.Init(new Food(500));
            }
        }

        // マップ上のCharactorがいなかったら（いなくなったら）配置する。
        void AddCharactor()
        {
            GameObject[] charactors = GameObject.FindGameObjectsWithTag("Charactor");

            if (charactors.Length == 0)
            {
                var newCharactor = InstantiateChild("Character", new Vector2(0, 0), gameObject.transform);
                var charactorComponent = newCharactor.AddComponent<CharactorComponent>();
                charactorComponent.Init(new Charactor());
            }
        }

    }
}