using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTreeAIExample
{
    public interface IBehaviorTreeNode
    {
        bool Act();
    }
}
