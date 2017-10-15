using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class ReproductionAction : ICharactorAction
    {
	    public bool Act ()
        {
            return true;
	    }
    }
}
