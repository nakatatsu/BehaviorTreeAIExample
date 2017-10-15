using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class Food
    {
        public readonly int InitialVolume = 500;
        public ReactiveProperty<int> Volume;
        public ReadOnlyReactiveProperty<bool> IsEated;

        public Food()
        {
            Volume = new ReactiveProperty<int>(InitialVolume);
            IsEated = Volume.Select(x => (x == 0)).ToReadOnlyReactiveProperty();
        }
    }
}