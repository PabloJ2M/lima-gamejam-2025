namespace UnityEngine.Audio
{
    public class AudioShot : MonoBehaviour
    {
        public void PlayOnShot(AudioClip clip) { if (clip) AudioManager.Instance.PlayOneShot(clip); }
    }
}