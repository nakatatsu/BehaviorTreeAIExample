using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class Position
    {
        public float X;
        public float Y;

        public double GetRange(Position other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }
    }
}
