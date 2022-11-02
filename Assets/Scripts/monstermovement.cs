using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class monstermovement : MonoBehaviour
{
    public Vector2 desiredpos;
    public Transform player;
    public float speed;
    public float offset;
    public bool still;
    public AudioSource footsteps;
    public AudioSource mSound;
    // Start is called before the first frame update
    protected void Start()
    {
        desiredpos = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    protected void Update()
    {
        Vector2 currentpos = new Vector2(transform.position.x, transform.position.z);
        Vector2 direction = desiredpos - currentpos;
        
        if (direction.magnitude <= offset)
        {
            transform.position = new Vector3(desiredpos.x, transform.position.y, desiredpos.y);
            still = true;
        }
        else
        {
            Vector2 newpos = currentpos + (direction.normalized * speed * Time.deltaTime);
            transform.position = new Vector3(newpos.x, transform.position.y, newpos.y);
            still = false;
        }
    }
}
