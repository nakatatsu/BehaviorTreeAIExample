﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;


namespace BehaviorTreeAIExample
{
    public class MoveTask : IBehaviorTreeNode
    {
        Position MyPosition;
        List<Position> FoodsPosition;
        Subject<ICharactorAction> EventListener;

        public MoveTask(Position myPosition, List<Position> foodsPosition, Subject<ICharactorAction> eventListener)
        {
            MyPosition = myPosition;
            FoodsPosition = foodsPosition;
            EventListener = eventListener;
        }


        public bool Act()
        {
            if (FoodsPosition.Count == 0)
                return false;

            double minRange = 0;
            var Index = 0;
            for (var i = 0; i < FoodsPosition.Count; i++)
            {
                var range = MyPosition.GetRange(FoodsPosition[i]);
                if (minRange < range)
                {
                    minRange = range;
                    Index = i;
                }
            }

            var action = new MoveAction() { X = JudgeStopOrMove(MyPosition.X, FoodsPosition[Index].X), Y = JudgeStopOrMove(MyPosition.Y, FoodsPosition[Index].Y) };
            EventListener.OnNext(action);

            return true;
        }

        int JudgeStopOrMove(float a, float b)
        {
            if (a > b)
                return -1;

            if (a < b)
                return 1;

            return 0;
        }

    }

}
