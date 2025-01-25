namespace UnityEngine.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioMixer _mixer;

        public readonly string[] parameters = { "Music", "Effects" }; 

        private void Start() { foreach (var item in parameters) SetMixerValue(item, PlayerPrefs.GetFloat(item, 0.5f)); }
        public void SetMixerValue(string name, float value) => _mixer.SetFloat(name, Mathf.Log10(value) * 20f);
    }
}