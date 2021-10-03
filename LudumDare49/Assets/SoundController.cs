using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] soundCollection;

    public int rand;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            rand = Random.Range(0, soundCollection.Length);
            audioSource.clip = soundCollection[rand];
            audioSource.Play();
        }
    }
}
