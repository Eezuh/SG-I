using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampfireScript_Camper : MonoBehaviour
{
    public AudioSource CampfireSource;
    public AudioSource NPCSource;
    public AudioSource StickFall;

    public AudioClip Humming;
    public AudioClip Line_01;
    public AudioClip StickEffect;
    public GameObject lake;

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
        StartCoroutine(Stick());
    }

    private IEnumerator Stick()
    {
        yield return new WaitForSeconds(21f);
        StickFall.PlayOneShot(StickEffect);
        lake.SetActive(true);
    }
}
