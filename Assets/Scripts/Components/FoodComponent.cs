using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class FoodComponent : BehaviourTreeExampleBehaviour
    {
        public Food Instance { get; private set; }

        void Init(Food food)
        {
            Instance = food;

            // 食べられたら消える。
            Instance.IsEated
                    .Subscribe(_ => Destroy(this))
                    .AddTo(gameObject);
        }


    }
}