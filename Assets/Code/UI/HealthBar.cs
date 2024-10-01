using Assets.Source.Code;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Write(int value, int maxValue)=>
            _slider.value = (float)value / maxValue;
    }
}