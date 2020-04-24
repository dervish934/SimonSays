using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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



    // AUDIOS TUTORIAL // 

    public AudioClip tutorial1;
    public AudioClip tutorial2;
    public AudioClip tutorial3;
    public AudioClip tutorial4;
    public AudioClip tutorial5;
    public AudioClip tutorial6;
    public AudioClip tutorial7;
    public AudioClip tutorial8;

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
                juego();
                choiceselected = true;

            }else if (tapCounter <= 1 && !choiceselected)
            {
                print("Tutorial");
                tutorial();
                choiceselected = true;
            }

        }
        
       



    
    }
    // AUDIOS /////////////////////////////////////////////////
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




    // TUTORIALES //////////////////////////////////////////////////

    void playtutorial1()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial1, 1f);
       
    }

    void playtutorial2()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial2, 1f);

    }

    void playtutorial3()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial3, 1f);

    }

    void playtutorial4()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial4, 1f);

    }

    void playtutorial5()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial5, 1f);

    }

    void playtutorial6()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial6, 1f);

    }

    void playtutorial7()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial7, 1f);

    }

    void playtutorial8()
    {
        shotSource1 = GetComponent<AudioSource>();
        shotSource1.PlayOneShot(tutorial8, 1f);

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
        Invoke("playtutorial1", 1);
        Invoke("playtutorial2", 2f);
        Invoke("playtutorial3", 6.2f);
        Invoke("playtutorial4", 10.2f);
        Invoke("playtutorial5", 13.45f);
        Invoke("playtutorial6", 14.45f);
        Invoke("playtutorial7", 18.45f);
        Invoke("playtutorial8", 24.0f);
        StartCoroutine(loadScene());
    }

    void juego()
    {
        SceneManager.LoadScene("SimonSays");

    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene("SimonSays");
    }

    

}
