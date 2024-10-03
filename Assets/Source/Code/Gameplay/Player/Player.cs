using Assets.Code.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(GroundChecker))]
    public class Player : MonoBehaviour, IPlayer, ILootCollector, IHealthDamageHandler, IHealthRegenerator
    {
        private CharacterStateMachine _stateMachine;
        private Health _health;
        private Transform _transform;

        public Rigidbody2D Rigidbody2D { get; private set; }
        public PlayerView View { get; private set; }
        public IInputService Input { get; private set; }
        public PlayerConfig Config { get; private set; }
        public GroundChecker GroundChecker { get; private set; }
        public CharacterController2D PlayerController { get; private set; }

        [Inject]
        private void Construct(IInputService inputService, PlayerConfig playerConfig, CharacterController2D controller, Health health)
        {
            _transform = transform;
            _health = health;
            Input = inputService;
            Config = playerConfig;
            PlayerController = controller;
        }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            View = GetComponent<PlayerView>();
            GroundChecker = GetComponent<GroundChecker>();
            View.Initialize(GetComponent<Animator>());
            PlayerController.Initialize(Rigidbody2D);
            _stateMachine = new CharacterStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }

        private void OnDestroy() =>
            _stateMachine.OnDestroy();

        public void TakeDamage(int value) =>
            _health.TakeDamage(value);

        public void Heal(int value) =>
            _health.Heal(value);

        public void Warp(Vector2 to) =>
            _transform.position = to;
    }
}