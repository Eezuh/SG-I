using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDocile : MonoBehaviour
{
    public GameObject DocileC;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        int r = Random.Range(1, 360);
        Vector3 spawnloc = Quaternion.Euler(0, r, 0) * other.transform.forward * radius + other.transform.position;
        spawnloc = new Vector3(spawnloc.x, 0.5f, spawnloc.z);
        GameObject d = Instantiate(DocileC);
        d.transform.position = spawnloc;
        d.GetComponent<DocileMonster>().player = other.transform;
        Destroy(gameObject);
    }
}
