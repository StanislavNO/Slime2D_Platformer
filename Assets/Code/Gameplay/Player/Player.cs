using UnityEngine;
using Zenject;


namespace Assets.Source.Code
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, ILootCollector
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private GroundChecker _groundChecker;

        private CharacterStateMachine _stateMachine;

        public PlayerView View => _view;
        public GroundChecker GroundChecker => _groundChecker;
        public IInputService Input { get; private set; }
        public PlayerConfig Config { get; private set; }
        public CharacterController2D PlayerController { get; private set; }

        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig, CharacterController2D controller)
        {
            Input = inputService;
            Config = playerConfig;
            PlayerController = controller;
            PlayerController.Initialize(GetComponent<Rigidbody2D>());
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