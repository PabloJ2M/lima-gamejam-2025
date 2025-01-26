namespace UnityEngine.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource _effects;
        private AudioMixer _mixer;

        public readonly string[] parameters = { "Music", "Effects" };

        protected override void Awake() { base.Awake(); _effects = GetComponent<AudioSource>(); _mixer = _effects.outputAudioMixerGroup.audioMixer; }
        private void Start() { foreach (var item in parameters) SetMixerValue(item, PlayerPrefs.GetFloat(item, 0.5f)); }
        public void SetMixerValue(string name, float value) => _mixer.SetFloat(name, Mathf.Log10(value) * 20f);
        public void PlayOneShot(AudioClip clip) => _effects.PlayOneShot(clip);
    }
}