using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Sound : MonoBehaviour
{
    public AudioClip classroomAmbiant;
    public AudioClip[] drawSounds;
    public AudioClip laugh;

    AudioSource audioSource;
    AudioSource backgroundAudio;
    public static Scene2Sound instance;

    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponents<AudioSource>()[0];
        backgroundAudio = GetComponents<AudioSource>()[1];
        backgroundAudio.clip = classroomAmbiant;
        backgroundAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayDrawSound()
    {
        audioSource.PlayOneShot(drawSounds[currentIndex++ % drawSounds.Length]);
    }

    public void PlayLaughSound()
    {
        backgroundAudio.Pause();
        audioSource.PlayOneShot(laugh);
    }

}
