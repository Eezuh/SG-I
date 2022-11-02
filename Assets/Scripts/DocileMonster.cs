using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public enum dstate
{
    fastaprouch,
    aprouch, 
    sniff, 
    backoff,
    attack
}
public enum direction
{
    front,left,right,back,none
}
public class DocileMonster : monstermovement
{
    public dstate state;
    public float fastdistance;
    public float fastSpeed;
    public float slowSpeed;
    public float closedistance;
    public float snifftime;
    public direction direction;
    public int timessniffed;
    public int timestosniff;
    public float timer;
    private List<int> adirs;
    public AudioClip running;
    public AudioClip walking;
    public AudioClip attacking;
    public AudioClip sniffing;
    public AudioClip call;
    private bool sniffed = false;
    private bool anounced = false;
    // Start is called before the first frame update
    void Start()
    {
        footsteps.clip = running;
        footsteps.Play();
        base.Start();
        speed = fastSpeed;
        adirs = new List<int>();
        adirs.Add(0); adirs.Add(1); adirs.Add(2); adirs.Add(3);
        timessniffed = 0;
    }

    private void BackOff()
    {
        footsteps.clip = running;
        if (!footsteps.isPlaying)
        {
            footsteps.Play();
        }
        speed = fastSpeed;
        Vector3 d = transform.position - player.position;
        Vector2 dir = new Vector2(d.x, d.z);
        desiredpos = dir * 10 + new Vector2(transform.position.x, transform.position.z);
        if (Vector3.Distance(transform.position,player.position) >= 50)
        {
            Destroy(gameObject);
        }
    }

    private void FastAprouch()
    {
        if (footsteps.clip != running)
        {
            footsteps.clip = running;
        }
        if (!footsteps.isPlaying)
        {
            footsteps.Play();
        }
        speed = fastSpeed;
        Vector3 d = transform.position - player.position;
        d.Normalize();
        desiredpos = new Vector2(d.x, d.z) * fastdistance + new Vector2(player.position.x, player.position.z);
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(player.position.x, player.position.z)) <= fastdistance)
        {
            if (anounced)
            {
                if (!mSound.isPlaying)
                {
                state = dstate.aprouch;
                    
                }
            }
            else
            {
                footsteps.Stop();
                mSound.clip = call;
                mSound.Play();
                anounced = true;
            }
           
        }
    }

    private void Attack()
    {
        if (footsteps.clip != running)
        {
            footsteps.clip = running;
        }
        if (!footsteps.isPlaying)
        {
            footsteps.Play();
        }   
        if (mSound.clip != attacking)
        {
            mSound.clip = attacking;
        }
        if (!mSound.isPlaying)
        {
            mSound.Play();
        }
        speed = fastSpeed;
        desiredpos = new Vector2(player.position.x, player.position.z);
    }

    private void Sniff()
    {
        throw new NotImplementedException();
    }

    private void Aprouch()
    {

        if (still)
        {

            if (!mSound.isPlaying)
            {
                if (sniffed)
                {
                    timessniffed++;
                    if (timessniffed >= timestosniff)
                    {
                        state = dstate.backoff;
                    }
                    else
                    {
                        direction = direction.none;
                    }
                    sniffed = false;
                }
                else
                {
                    mSound.clip = sniffing;
                    mSound.Play();
                    sniffed = true;
                    footsteps.Stop();
                }

            }
        }
        else { timer = 0;
            if (footsteps.clip != walking)
            {
                footsteps.clip = walking;
            }
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
            }
        }

        if (direction == direction.none)
        {
            int i = Random.Range(0, adirs.Count);
            direction = (direction)adirs[i];
            adirs.RemoveAt(i);

        }
        speed = slowSpeed;
        Vector3 d;
        switch (direction)
        {
            case direction.front:
                d = player.forward * closedistance + player.position;

                break;
            case direction.left:
                d = player.right * -1 * closedistance + player.position;
                break;
            case direction.right:
                d = player.right * closedistance + player.position;
                break;
            case direction.back:
                d = player.forward * -1 * closedistance + player.position;
                break;
            default:
                d = player.forward * -1 * closedistance + player.position;
                break;
        }
        desiredpos = new Vector2(d.x, d.z);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        switch (state)
        {
            case dstate.aprouch:
                Aprouch();
                break;
            case dstate.sniff:
                Sniff();
                break;
            case dstate.attack:
                Attack();
                break;
            case dstate.fastaprouch:
                FastAprouch();
                break;
            case dstate.backoff:
                BackOff();
                break;
            default:
                break;
        }

    }
}
