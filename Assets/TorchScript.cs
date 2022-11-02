using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorchScript : MonoBehaviour
{
    float CurrentMouseXPos;
    float PreviousMouseXPos;
    float CurrentMouseYPos;
    float PreviousMouseYPos;
    float traveledDistance;
    public float DistanceThreshold;
    public float FastThreshold;

    public GameObject Player;
    public GameObject Torch;
    public Camera TorchCamera;
    public float TranslationSpeed;

    int TorchMovementSpeed; //0 = static, 1 = slow, 2 = fast

    float ScreenPercentageX;
    float ScreenPercentageY;

    public GameObject TorchAudioPerpObj;
    public GameObject TorchAudioSwingsObj;

    private AudioSource TorchAudioPerpSource;
    private AudioSource TorchAudioSwingsSource;

    public AudioClip AudioIgnite;
    public AudioClip AudioPerp;
    public AudioClip AudioSwing01;
    public AudioClip AudioSwing02;

    private float SwingCooldownStart;
    public float SwingCooldownLength;
    private bool inSwingCooldown;

    public bool PlayerIsSwinging;


    private void Start()
    {
        inSwingCooldown = true;
        SwingCooldownStart = Time.time;

        PreviousMouseXPos = 0;
        PreviousMouseYPos = 0;

        TorchAudioPerpSource = TorchAudioPerpObj.GetComponent<AudioSource>();
        TorchAudioSwingsSource = TorchAudioSwingsObj.GetComponent<AudioSource>();

        TorchAudioPerpSource.PlayOneShot(AudioIgnite); //Should there also be an option to un-ignite the torch at will?
        TorchAudioPerpSource.clip = AudioPerp;
        TorchAudioPerpSource.Play();
    }

    private void Update()
    {
        if (Time.time > (SwingCooldownStart + SwingCooldownLength))
        {
            inSwingCooldown = false;
        }

        PreviousMouseXPos = CurrentMouseXPos;
        PreviousMouseYPos = CurrentMouseYPos;
        CurrentMouseXPos = Input.mousePosition.x;
        CurrentMouseYPos = Input.mousePosition.y;

        CalculateMouseAccel();
        MoveTorchObject();
    }

    void CheckAccelThreshold()
    {

    }

    void CalculateMouseAccel()
    {
        traveledDistance = Mathf.Sqrt(Mathf.Pow(CurrentMouseXPos - PreviousMouseXPos, 2) + Mathf.Pow(CurrentMouseYPos - PreviousMouseYPos, 2));
        if (traveledDistance >= DistanceThreshold && traveledDistance < FastThreshold)
        {
            PlayerIsSwinging = true;
            TorchMovementSpeed = 1;
        }
        else if (traveledDistance > FastThreshold)
        {
            PlayerIsSwinging = true;
            TorchMovementSpeed = 2;
            PlayTorchSound("swing");
        }
        else
        {
            PlayerIsSwinging = false;
            TorchMovementSpeed = 0;
        }
    }

    void MoveTorchObject() //doesnt work yet...
    {
        ScreenPercentageX = Input.mousePosition.x / Screen.width * 100;
        ScreenPercentageY = Input.mousePosition.y / Screen.height * 100;
        float calculatedTorchPosX = -0.55f + (1.10f / 100 * ScreenPercentageX);
        float calculatedTorchPosY = (-0.05f + (0.50f / 100 * ScreenPercentageY))-1;

        //this.gameObject.transform.Translate(new Vector3(calculatedTorchPosX, calculatedTorchPosY) * Time.deltaTime, Space.Self);
        this.gameObject.transform.localPosition = new Vector2(calculatedTorchPosX, calculatedTorchPosY); //isnt relative to player rotation;
        //this.gameObject.transform.Translate(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));
        //this.gameObject.transform.rotation = Player.transform.rotation;


    }

    void PlayTorchSound(string action)
    {
        switch (action)
        {
            case "swing":
                int rand = Random.Range(1, 3);
                if (inSwingCooldown == false)
                {
                    if (rand == 1)
                    {
                        Debug.Log("Swingaudio");
                        TorchAudioSwingsSource.PlayOneShot(AudioSwing01);
                        SwingCooldownStart = Time.time;
                        inSwingCooldown = true;
                    }
                    else
                    {
                        Debug.Log("Swingaudio");
                        TorchAudioSwingsSource.PlayOneShot(AudioSwing02);
                        SwingCooldownStart = Time.time;
                        inSwingCooldown = true;
                    }
                }
                break;

        }
    }


}


