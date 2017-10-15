using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class CharactorComponent : BehaviourTreeExampleBehaviour
    {
        public Charactor Instance { get; private set; }


        void Init(Charactor instance)
        {
            Instance = instance;

            // Foodと接触したら捕食
            this.OnCollisionEnter2DAsObservable()
                .Where(collider => collider.gameObject.tag == "Food")
                .Subscribe(collider => Instance.Eat(collider.gameObject.GetComponent<FoodComponent>().Instance))
                .AddTo(gameObject);
        }



        void Think()
        {
            // 世界を知覚する。
            // Foodがどこにあるか知覚
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");


            // 知覚した世界と自分の状態をもとに考える/動く
            var root = new Selector();


        }


    }
}