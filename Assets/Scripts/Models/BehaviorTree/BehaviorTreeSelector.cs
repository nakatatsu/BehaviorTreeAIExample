using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTreeAIExample
{
    public class BehaviorTreeSelector : IBehaviorTreeNode
    {
        public List<IBehaviorTreeNode> NodeList { get; set; }

        public BehaviorTreeSelector()
        {
            NodeList = new List<IBehaviorTreeNode>();
        }

        public BehaviorTreeSelector Add(IBehaviorTreeNode node)
        {
            NodeList.Add(node);
            return this;
        }

        public bool Act()
        {
            for (var i = 0; i < NodeList.Count; i++)
            {
                if (NodeList[i].Act())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
