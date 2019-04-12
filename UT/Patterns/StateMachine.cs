using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT.Patterns
{
    public class StateMachine<Value, Input>
    {
        public Dictionary<int, IState<Value, Input>> states;

        public IState<Value, Input> state;

        public StateMachine()
        {
            states = new Dictionary<int, IState<Value, Input>>();
        }

        public void SwitchState(int newState, Value value)
        {
            state.Exit(value);
            if (states.TryGetValue(newState, out state)) {
                state.Enter(value);
            }
        }
    }

    public interface IState<Value, Input>
    {
        void Enter(Value value);
        void Exit(Value value);

        void HandleInput(Value value, Input input);
        void UpdateState(Value value);
    }
}