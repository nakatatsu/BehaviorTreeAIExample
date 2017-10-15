using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class Charactor
    {
        public readonly int InitialLife = 1000;
        public readonly int ReproductionFoods = 2000;
        public ReadOnlyReactiveProperty<bool> IsDead;
        public ReactiveProperty<int> Life;

        public Charactor()
        {
            Life = new ReactiveProperty<int>(InitialLife);
            IsDead = Life.Select(x => (x <= 0)).ToReadOnlyReactiveProperty();
        }

        public void Tictac()
        {
            Life.Value--;
        }

        public void Eat(Food food)
        {
            Life.Value += food.Volume.Value;
            food.Volume.Value = 0;
        }
    }
}