using UnityEngine.UI;

namespace UnityEngine.Audio
{
    [RequireComponent(typeof(Slider))]
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private string _name;
        private AudioManager _manager;
        private Slider _slider;

        private void Awake() { _manager = AudioManager.Instance; _slider = GetComponent<Slider>(); }
        private void OnEnable() => _slider.onValueChanged.AddListener(SetValue);
        private void OnDisable() => _slider.onValueChanged.RemoveAllListeners();

        private void SetValue(float value)
        {
            _manager?.SetMixerValue(_name, value);
            PlayerPrefs.SetFloat(_name, value);
        }
    }
}