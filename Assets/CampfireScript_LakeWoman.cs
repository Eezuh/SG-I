using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireScript_LakeWoman : MonoBehaviour
{
    public AudioSource NPCSource;

    public AudioClip Line_01;
    public GameObject sea;
    public GameObject Cricket01;
    public GameObject Cricket02;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            NPCSource.PlayOneShot(Line_01);
            sea.SetActive(true);
            Cricket01.SetActive(false);
            Cricket02.SetActive(true);

        }
    }
}
