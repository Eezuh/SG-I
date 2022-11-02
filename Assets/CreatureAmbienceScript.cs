using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAmbienceScript : MonoBehaviour
{
    public AudioClip CreatureAmbienceClip;
    public AudioSource ThisAudioSource;
    public int FrequencyProfile; //1 = constant, 2 is frequent, 3 every now and then

    private void Start()
    {
        ThisAudioSource = this.gameObject.GetComponentInChildren<AudioSource>();
        ThisAudioSource.clip = CreatureAmbienceClip;

        switch (FrequencyProfile)
        {
            case 1:
                ThisAudioSource.Play();
                break;

            case 2:
                StartCoroutine(Frequent());
                break;

            case 3:
                StartCoroutine(Sometimes());
                break;
        }
    }

    IEnumerator Frequent()
    {
        ThisAudioSource.PlayOneShot(ThisAudioSource.clip);
        int randomWaitingTime = Random.Range(5, 10);
        yield return new WaitForSeconds(randomWaitingTime);
        StartCoroutine(Frequent());
    }

    IEnumerator Sometimes()
    {
        ThisAudioSource.PlayOneShot(ThisAudioSource.clip);
        int randomWaitingTime = Random.Range(20, 60);
        yield return new WaitForSeconds(randomWaitingTime);
        StartCoroutine(Sometimes());
    }
}
