using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Player : MonoBehaviour, ILootCollector
    {
        [SerializeField] private GroundChecker _groundChecker;

        private CharacterStateMachine _stateMachine;

        public GroundChecker GroundChecker => _groundChecker;
        public PlayerView View { get; private set; }
        public IInputService Input { get; private set; }
        public PlayerConfig Config { get; private set; }
        public CharacterController2D PlayerController { get; private set; }

        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig, CharacterController2D controller)
        {
            Input = inputService;
            Config = playerConfig;
            PlayerController = controller;
        }

        private void Awake()
        {
            View = GetComponent<PlayerView>();
            PlayerController.Initialize(GetComponent<Rigidbody2D>());
            View.Initialize(GetComponent<Animator>());
            _stateMachine = new CharacterStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }
    }
}