using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFirstScene : MonoBehaviour
{

    public AudioClip shot1;
    public AudioClip shot2;
    public AudioClip shot3;
    AudioSource shotSource1;

    int tapCounter = 0;

    bool inputLoad = false;
    bool taped = false;
    bool timesOver = false;

    float secondsTap = 60;

    bool choiceselected = false;

    // Start is called before the first frame update

    public void OnMouseDown()
    {
        Debug.Log("Me estas presionando");

        if (inputLoad)
        {
            tapCounter++;
            taped = true;
            print(tapCounter);
            // Debug.Log(tapCounter);

        }


    }

    public void Start()
    {

        playFirstAudio();
        Invoke("playSecondAudio", 7);
        Invoke("playThirdAudio", 12);

    }


    public void Update()
    {
        if (taped)
        {
            timer();
        }

        if (timesOver)
        {
            if (tapCounter >= 2 && !choiceselected)
            {
                print("juego");
                choiceselected = true;

            }else if (tapCounter <= 1 && !choiceselected)
            {
                print("Tutorial");
                choiceselected = true;
            }

        }
        
       



    
    }

    void playFirstAudio()
    {
            shotSource1 = GetComponent<AudioSource>();
            shotSource1.PlayOneShot(shot1, 1f);
    }

    void playSecondAudio()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(shot2, 1f);
    }

    void playThirdAudio()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(shot3, 1f);
        inputLoad = true;
    }

    void timer()
    {
        secondsTap -= 1;
        if (secondsTap <= 0)
        {
            taped = false;
            secondsTap = 1;
            timesOver = true;
            


        }

    }

    void tutorial()
    {
        print("TUTORIAL");

    }

    void juego()
    {
        print("JUEGO");

    }


    

}
