using UnityEngine;

public class KeyboardAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode to the desired key
        {
            PlayAudio();
        }
    }

    private void PlayAudio()
    {
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}