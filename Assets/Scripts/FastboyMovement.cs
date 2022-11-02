using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum bstate
{
    encircling,
    observing,
    attacking,
    whimpering
} 
public class FastboyMovement : monstermovement
{
    public float radius;
    public bstate state;
    private float timer = 0;
    public float AsaultTime;
    public bool scared;
    public AudioClip whimpering;
    public AudioClip running;
    public AudioClip attacking;
    public AudioClip howling;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        state = (bstate)Random.Range(0, 1);
        if (mSound.clip != running) { mSound.clip = howling; }
        if (!mSound.isPlaying) { mSound.Play(); }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= AsaultTime && !scared)
        {
            state = bstate.attacking;
        }
        if (scared)
        {
            state = bstate.whimpering;
        }
        base.Update();
        switch (state)
        {
            case bstate.encircling:
                Encircling();
                break;
            case bstate.observing:
                DistantObserve();
                break;
            case bstate.attacking:
                Attack();
                break;
            case bstate.whimpering:
                Whimpering();
                break;
            default:
                break;
        }
    }

    private void Whimpering()
    {
        if (footsteps.clip != running) { footsteps.clip = running; }
        if (!footsteps.isPlaying) { footsteps.Play(); }
        if (mSound.clip != running) { mSound.clip = whimpering; }
        if (!mSound.isPlaying) { mSound.Play(); }
        Vector3 d = transform.position - player.position;
        Vector2 dir = new Vector2(d.x, d.z);
        desiredpos = dir * 10 + new Vector2(transform.position.x, transform.position.z);
        if (Vector3.Distance(transform.position, player.position) >= 50)
        {
            Destroy(gameObject);
        }
    }

    void Encircling()
    {
        if (footsteps.clip != running) { footsteps.clip = running; }
        if (!footsteps.isPlaying) { footsteps.Play(); }
        Vector3 d = transform.position - player.position;
        d.Normalize();
        Vector3 cd = Quaternion.Euler(0,5,0) * d;
        desiredpos = new Vector2(cd.x, cd.z) * radius + new Vector2(player.position.x, player.position.z) ;
    }

    void DistantObserve()
    {
        if (footsteps.clip != running) { footsteps.clip = running; }
        if (footsteps.isPlaying) { footsteps.Stop(); }
        Vector3 d = transform.position - player.position;
        d.Normalize();
        desiredpos = new Vector2(d.x, d.z) * radius + new Vector2(player.position.x, player.position.z);
    }
    void Attack()
    {
        if (footsteps.clip != running) { footsteps.clip = running; }
        if (!footsteps.isPlaying) { footsteps.Play(); }
        if (mSound.clip != running) { mSound.clip = attacking; }
        if (!mSound.isPlaying) { mSound.Play(); }
        desiredpos = new Vector2(player.position.x, player.position.z); 
    }
}
