using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireScript_Camper : MonoBehaviour
{
    public AudioSource CampfireSource;
    public AudioSource NPCSource;
    public AudioSource StickFall;

    public AudioClip Humming;
    public AudioClip Line_01;
    public AudioClip StickEffect;

    void Start()
    {
        NPCSource.clip = Humming;
        CampfireSource.Play();
        NPCSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            NPCSource.Stop();
            Debug.Log("Playing NPC Dialog");
            StartCoroutine(WaitAndPlay());
        }
    }

    private IEnumerator WaitAndPlay()
    {
        yield return new WaitForSeconds(2f);
        NPCSource.PlayOneShot(Line_01);
        StickFall.PlayOneShot(StickEffect);
    }
}
