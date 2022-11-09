using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public AudioSource Introdialog;
    private float startttime;
    private void Start()
    {
        Introdialog.Play();
        startttime = Time.time;
    }

    private void Update()
    {
        if(Time.time >= startttime + 58f)
        {
            SceneManager.LoadScene("ForestScene");
        }
    }
}
