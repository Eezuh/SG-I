using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLocTriggerScript : MonoBehaviour
{
    public GameObject Sailor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Sailor.GetComponent<CampfireScript_Sailor>().InFinalPosition = true;
        }
    }
}
