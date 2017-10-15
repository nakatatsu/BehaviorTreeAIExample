using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTreeAIExample
{
    public class BehaviorTreeSequence : IBehaviorTreeNode
    {
        public List<IBehaviorTreeNode> NodeList { get; set; }

        public bool Act()
        {
            for (var i = 0; i < NodeList.Count; i++)
            {
                if (!NodeList[i].Act())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
