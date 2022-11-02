using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bigstate
{
    Anounce, 
    Chase
}
public class BigMovement : monstermovement
{
    public bigstate state;
    public float anounceTime;
    public float anouncedis;
    public bool arrived;
    public float timer;
    public AudioClip aprouchfootsteps;
    public AudioClip chasefootsteps;
    public AudioClip anounceGrowl;
    private bool hasanounced = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        footsteps.clip = aprouchfootsteps;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        switch (state)
        {
            case bigstate.Anounce:
                Anounce();
                break;
            case bigstate.Chase:
                Chase();
                break;
            default:
                break;
        }
        if (Vector3.Distance(transform.position, player.position) >= 50)
        {
            Destroy(gameObject);
        }
    }

    void Anounce()
    {


        if (arrived)
        {
            footsteps.Stop();
            
            if (!mSound.isPlaying)
            {

                if (!hasanounced)
                {
                    mSound.clip = anounceGrowl;
                    mSound.Play();
                    hasanounced = true;
                }
                else
                {
                    state = bigstate.Chase;
                    footsteps.clip = chasefootsteps;
                    footsteps.Play();
                }
                
            }
        }
        else
        {
            Vector3 d = transform.position - player.position;
            d.Normalize();
            desiredpos = new Vector2(d.x, d.z) * anouncedis + new Vector2(player.position.x, player.position.z);
        }
        float distance = Vector3.Distance(transform.position,player.position);
        if (distance <= anouncedis && !arrived)
        {
            arrived = true;
            timer = 0;
        }


    }
    void Chase()
    {
        desiredpos = new Vector2(player.position.x,player.position.z);

    }
}
