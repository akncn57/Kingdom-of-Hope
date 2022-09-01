using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomOfHope.StateMachines
{
    public class StateMachine : MonoBehaviour
    {
        private List<StateTransition> stateTransitions = new List<StateTransition>();
        private List<StateTransition> anyStateTransitions = new List<StateTransition>();
        private IState currentState;

        /// <summary>
        ///  This method set new state.
        /// </summary>
        /// <param name="state"> Get next state. </param>
        public void SetState(IState state)
        {
            if (state == currentState) return;
            currentState?.OnExit();
            currentState = state;
            currentState.OnEnter();
        }

        public void Tick()
        {
            StateTransition stateTransition = CheckForTransition();

            if (stateTransition != null)
            {
                SetState(stateTransition.To);
            }
            
            currentState.Tick();
        }
        
        /// <summary>
        ///  This method make the state transition.
        /// </summary>
        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;
            }
            
            foreach (StateTransition stateTransition in stateTransitions)
            {
                if (stateTransition.Condition() && stateTransition.From == currentState)
                {
                    return stateTransition;
                }
            }

            return null;
        }
        
        /// <summary>
        ///  This method add new transition.
        /// </summary>
        /// <param name="from"> Get current state. </param>
        /// <param name="to"> Get next state. </param>
        /// <param name="condition"> Get transition condition. </param>
        public void AddTransition(IState from, IState to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            stateTransitions.Add(stateTransition);
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null, to, condition);
            anyStateTransitions.Add(anyStateTransition);
        }
    }   
}
