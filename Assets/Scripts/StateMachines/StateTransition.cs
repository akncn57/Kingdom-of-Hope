using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomOfHope.StateMachines
{
    public class StateTransition
    {
        private IState from;
        private IState to;
        System.Func<bool> condition;

        public IState From => from;
        public IState To => to;
        public System.Func<bool> Condition => condition;

        public StateTransition(IState from, IState to, System.Func<bool> condition)
        {
            this.from = from;
            this.to = to;
            this.condition = condition;
        }
    }   
}