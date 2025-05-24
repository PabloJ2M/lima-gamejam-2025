using UnityEngine;

public class DeathAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private bool enable;


    private void Start()
    {
        enable = true;
        audioSource = GetComponent<AudioSource>();
    }

    public void DeathMessage()
    {
        //if (enable)
        //{
        //    if (deathSounds.Length > 0)
        //    {
        //        AudioClip selectedClip = deathSounds[Random.Range(0, deathSounds.Length)];
        //        audioSource.PlayOneShot(selectedClip);

        //        enable = false;
        //    }
        //}
    }
}