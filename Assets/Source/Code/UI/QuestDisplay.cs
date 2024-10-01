using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class QuestDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;

        private int _maxScore;

        public void SetMaxScore(int maxValue) =>
            _maxScore = maxValue;

        public void WriteScore(int currentValue) =>
            _score.text = $"{currentValue}/{_maxScore}";
    }
}