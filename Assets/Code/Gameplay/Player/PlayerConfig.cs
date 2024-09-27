using UnityEngine;

namespace Assets.Source.Code
{

    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/CharacterConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private RunningStateConfig _runningStateConfig;
        [SerializeField] private AirborneStateConfig _airborneStateConfig;

        public RunningStateConfig RunningStateConfig => _runningStateConfig;
        public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    }
}
