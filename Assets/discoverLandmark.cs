using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class discoverLandmark : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newlandmark;
    private AudioSource source;
    private AudioSource othersource;
    public bool discovered;
    float timer = 0;
    void Start()
    {
        discovered = false;
        source = GetComponent<AudioSource>();
        othersource = newlandmark.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (discovered)
        {
            timer += Time.deltaTime * .1f;
            source.volume = 1 - timer;
            othersource.volume = 0 + timer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        discovered = true;
    }
}
