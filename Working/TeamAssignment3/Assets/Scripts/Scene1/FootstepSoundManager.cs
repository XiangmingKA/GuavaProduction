using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundManager : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip threeYears;
    public AudioClip sixYears;
    public AudioClip tenYears;
    public static FootstepSoundManager instance;

    AudioSource audioSource;
    int currentIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = threeYears;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footsteps[currentIndex++ % footsteps.Length]);
    }

    public void PlayThreeYears()
    {
        audioSource.PlayOneShot(threeYears);
    }

    public void PlaySixYears()
    {
        audioSource.PlayOneShot(sixYears);
    }

    public void PlayTenYears()
    {
        audioSource.PlayOneShot(tenYears);
    }

}
