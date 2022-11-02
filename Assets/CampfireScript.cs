using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireScript : MonoBehaviour
{
    public AudioSource CampfireSource;
    public AudioSource NPCSource;

    void Start()
    {
        CampfireSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Debug.Log("Playing NPC Dialog");
            NPCSource.PlayOneShot(NPCSource.clip);
        }
    }
}
