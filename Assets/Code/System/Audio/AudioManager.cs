namespace UnityEngine.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioMixer _mixer;

        private void Start()
        {
            
        }
        public void SetMixerValue(string name, float value) => _mixer.SetFloat(name, Mathf.Log10(value) * 20f);
    }
}