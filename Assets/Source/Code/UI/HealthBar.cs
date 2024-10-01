using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Write(int currentHP, int maxHP)
        {
            float newValue = (float)currentHP / maxHP;
            _slider.value = newValue;
        }
    }
}