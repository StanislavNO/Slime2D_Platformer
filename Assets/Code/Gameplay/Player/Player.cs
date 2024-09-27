using UnityEngine;
using Zenject;


namespace Assets.Source.Code
{
    [RequireComponent(typeof(CharacterController2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private PlayerView _view;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private CharacterController2D _playerController;

        private CharacterStateMachine _stateMachine;

        public IInputService Input {get; private set;}
        public CharacterController2D PlayerController => _playerController;
        public PlayerConfig Config => _config;
        public PlayerView View => _view;
        public GroundChecker GroundChecker => _groundChecker;

        [Inject]
        private void Construct(IInputService inputService)
        {
            Input = inputService;
        }

        private void Awake()
        {
            _view.Initialize();
            _stateMachine = new CharacterStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }
    }
}