using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRigidBody;
    public float MovementSpeed;
    public float RotationSpeed;
    public AudioSource FootstepsSource;
    public AudioClip FS_Wood;
    public AudioClip FS_Leaves;
    public AudioClip FS_Puddle;
    public AudioClip FS_Stone;

    private bool IsWalkingA;
    private bool IsWalkingS;
    private bool IsWalkingW;
    private bool IsWalkingD;
    private bool IsWalking;

    void Start()
    {
        IsWalking = false;
        IsWalkingA = false;
        IsWalkingS = false;
        IsWalkingD = false;
        IsWalkingW = false;

        FootstepsSource.clip = FS_Stone;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(new Vector3(0, -RotationSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, MovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, -MovementSpeed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsWalking == false)
            {
                IsWalkingW = true;
                FootstepsSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (IsWalking == false)
            {
                IsWalkingS = true;
                FootstepsSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            IsWalkingW = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            IsWalkingS = false;
        }

        if (IsWalkingW == false && IsWalkingS == false)
        {
            FootstepsSource.Stop();
            IsWalking = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 10:
                FootstepsSource.clip = FS_Leaves;
                FootstepsSource.Play();
                break;
            case 11:
                FootstepsSource.clip = FS_Wood;
                FootstepsSource.Play();
                break;
            case 12:
                FootstepsSource.clip = FS_Stone;
                FootstepsSource.Play();
                break;
            case 13:
                FootstepsSource.clip = FS_Puddle;
                FootstepsSource.Play();
                break;
        }

    }
}
