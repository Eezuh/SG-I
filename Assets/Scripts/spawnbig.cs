using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbig : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bigC;
    public float radius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            int r = Random.Range(1, 360);
            Vector3 spawnloc = Quaternion.Euler(0, r, 0) * other.transform.forward * radius + other.transform.position;
            spawnloc = new Vector3(spawnloc.x, 0.5f, spawnloc.z);
            GameObject b = Instantiate(bigC);
            b.transform.position = spawnloc;
            b.GetComponent<BigMovement>().player = other.transform;
            Destroy(gameObject);
        }
    }
}
