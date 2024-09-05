using System;
using System.Collections.Generic;

namespace IndustrialPlant.Infrastructure.StateMachine
{
    public class BaseStateMachine : IStateMachine
    {
        private IExitable currentState;
        private Dictionary<Type, IExitable> registeredStates = new();

        public void Enter<TState>() where TState : class, IState
        {
            ChangeState<TState>().Enter();
        }

        public void RegisterState(Type type, IExitable state)
        {
            registeredStates ??= new Dictionary<Type, IExitable>();
            registeredStates[type] = state;
        }

        private TState ChangeState<TState>() where TState : class, IExitable
        {
            currentState?.Exit();

            TState state = GetState<TState>();
            currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitable
        {
            return registeredStates[typeof(TState)] as TState;
        }
    }
}