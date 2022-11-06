using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireScript_Sailor : MonoBehaviour
{
    //public AudioSource CampfireSource;
    public AudioSource NPCSource;
    public AudioSource BehindPlayer;
    public GameObject Player;

    public AudioClip Hey;
    public AudioClip Line_01;
    public AudioClip Line_02;
    public bool InFinalPosition;
    public float Distance;
    private bool isFinal;

    void Start()
    {
        InFinalPosition = false;
        NPCSource.clip = Hey;
        //CampfireSource.Play();
        NPCSource.Play();
        isFinal = false;
    }

    private void Update()
    {
        if (InFinalPosition && !isFinal)
        {
            BehindPlayer.gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - Distance);
            StartCoroutine(FinalLine());
            isFinal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
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
    }

    private IEnumerator FinalLine()
    {
        yield return new WaitForSeconds(2f);
        BehindPlayer.PlayOneShot(Line_02);
    }
}
