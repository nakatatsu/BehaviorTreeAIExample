using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class BehaviourTreeExampleBehaviour : MonoBehaviour
    {
        protected GameObject InstantiateChild(string resourceName, Vector2 position, Transform transform)
        {
            var child = Instantiate(Resources.Load(resourceName), transform.position, transform.rotation) as GameObject;
            child.transform.SetParent(transform, false);
            child.transform.localPosition = position;
            return child;
        }
    }
}
