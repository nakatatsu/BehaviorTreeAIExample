using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class Food
    {
        public readonly int MaxVolume = 5;
        public ReactiveProperty<int> Volume;
        public ReadOnlyReactiveProperty<bool> IsEated;
        public ReactiveProperty<int> Life;

        public Food(int volume)
        {
            Volume = new ReactiveProperty<int>(volume);
            IsEated = Volume.Select(x => (x == 0)).ToReadOnlyReactiveProperty();
        }
    }
}