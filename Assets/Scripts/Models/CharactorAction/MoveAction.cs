using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class MoveAction : ICharactorAction
    {
        public int X;
        public int Y;
    }
}