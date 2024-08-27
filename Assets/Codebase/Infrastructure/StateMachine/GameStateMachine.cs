using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.States
{
	public class GameStateMachine : IInitializable
    {
        private readonly StateFactory _stateFactory;

        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

		public void Initialize()
		{
			_states = new Dictionary<Type, IExitableState>
			{
				[typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
				[typeof(MainMenuState)] = _stateFactory.CreateState<MainMenuState>(),
				[typeof(NewGameState)] = _stateFactory.CreateState<NewGameState>(),
                [typeof(ContinueGameState)] = _stateFactory.CreateState<ContinueGameState>(),
                [typeof(IntroState)] = _stateFactory.CreateState<IntroState>(),
				[typeof(LoadLevelState)] = _stateFactory.CreateState<LoadLevelState>(),
				[typeof(DefaultState)] = _stateFactory.CreateState<DefaultState>(),  
			};

			Enter<BootstrapState>();
		}

		public void Enter<TState>() where TState : class, IPayLoadedState
        {
            IPayLoadedState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

		private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            Debug.Log($"<color=green>{state.GetType()}</color>");

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}