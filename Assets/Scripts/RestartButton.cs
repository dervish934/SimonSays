using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public SimonManager botonreiniciar;
    public AudioSource sonidoreinicio;
    public GameObject restartText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void OnMouseDown()
    {
        if (botonreiniciar.gameoverButton)
        {
            sonidoreinicio.Play();
            botonreiniciar.Reiniciar();
        }
       
    }


}
