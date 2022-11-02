using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTerrainScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            switch (this.gameObject.layer)
            {
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
            }
        }
    }
}
