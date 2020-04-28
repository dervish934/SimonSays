using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public SimonManager botonreiniciar;
    public AudioSource sonidoreinicio;
    public GameObject restartText;

    private int tapCounter = 0;
    bool taped = false;
    private float secondsTap = 60f;
    private bool timesOver = false;
    private bool choiceselected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void OnMouseDown()
    {

        if (botonreiniciar.gameoverButton)
        {
            tapCounter++;
            taped = true;
            print(tapCounter);
        }
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
                print("Volver a primera escena");
                choiceselected = true;
                StartCoroutine(loadFirstScene());

            }
            else if (tapCounter <= 1 && !choiceselected)
            {
                print("Reiniciar");
                choiceselected = true;
                reiniciar();
            }

        }





    }

    void reiniciar()
    {
        sonidoreinicio.Play();
        botonreiniciar.Reiniciar();
        timesOver = false;
        choiceselected = false;
        tapCounter = 0;
        /*if (botonreiniciar.gameoverButton)
        {
           
        }*/

    }

    void timer()
    {
        secondsTap -= 1;
        if (secondsTap <= 0)
        {
            taped = false;
            secondsTap = 60;
            timesOver = true;



        }

    }


    private IEnumerator loadFirstScene()
    {
        choiceselected = false;
        timesOver = false;
        tapCounter = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Manual_scene");

    }

}
