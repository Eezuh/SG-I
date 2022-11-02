using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contact");
        switch (other.gameObject.tag)
        {
            case "DocileMon":

                Debug.Log("ContactD");
                other.gameObject.GetComponent<DocileMonster>().FinalSmash();
                alive = false;
                break;
            case "FastMon":
                Debug.Log("ContactF");
                other.gameObject.GetComponent<FastboyMovement>().FinalSmash();
                alive = false;
                break;
            case "BigMon":

                Debug.Log("ContactB");
                other.gameObject.GetComponent<BigMovement>().FinalSmash();
                alive = false;
                break;
            default:
                break;
        }
    }
}
