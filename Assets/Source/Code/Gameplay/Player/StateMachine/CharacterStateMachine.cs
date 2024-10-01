using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Code
{
    public class CharacterStateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public CharacterStateMachine(Player character)
        {
            StateMachineData data = new StateMachineData();

            _states = new List<IState>()
            {
                new IdlingState(this, data, character),
                new RunningState(this, data, character),
                new FallingState(this, data, character),
                new JumpingState(this, data, character),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void OnDestroy() =>
            _currentState.Exit();

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void HandleInput() => _currentState.HandleInput();

        public void Update() => _currentState.Update();
    }
}