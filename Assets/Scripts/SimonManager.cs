using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimonManager : MonoBehaviour
{

    public FeedbackControl[] buttons;
    public List<int> ListaAleatoria = new List<int>();

    public bool ListaLlena;
    public bool turnoPc;
    public bool turnoPlayer;
    

    public int Contador;
    public int ContadorUsuario;
    public int NivelActual;

    [Range(0.1f, 2f)]
    public float Velocidad;

    //public Slider sliderVel;
    //public Text SliderText;
    //public Text gameOverText;
    //public Text Nivel;


    // Start is called before the first frame update


    private void Start()
    {

        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPC", 0.5f);

    }
    void LlenarListaAleatoria()
    {
        for (int i = 0; i <= 1000; i++)
        {
            ListaAleatoria.Add(Random.Range(0, 4));

        }
        ListaLlena = true;
    }

    public void cambiarEstado()
    {
        if (turnoPc)
        {
            turnoPc = false;
            turnoPlayer = true;

        }
        else
        {
            turnoPc = true;
            turnoPlayer = false;
            Contador = 0;
            ContadorUsuario = 0;
            Invoke("TurnoPC", 1.2f);
        }

    }

    void TurnoPC()
    {
        if (ListaLlena && turnoPc)
        {
            buttons[ListaAleatoria[Contador]].ActivateButton();


            if (Contador >= NivelActual)
            {
                NivelActual++;
                cambiarEstado();

            }
            else
            {
                Contador++;
            }
            Invoke("TurnoPC", Velocidad);

        }
    }


    public void ClickUsuario(int idButton)
    {
        if (idButton != ListaAleatoria[ContadorUsuario])
        {
            print("Game Over");
            GameOver();
            return;

        }

        if (ContadorUsuario == Contador)
        {

            cambiarEstado();
        }else
        {

            ContadorUsuario++;
        }

    }

    public void GameOver()
    {

        turnoPc = false;
        turnoPlayer = false;

    }

    public void Reiniciar()
    {
        Contador = 0;
        ContadorUsuario = 0;
        NivelActual = 0;
        ListaAleatoria.Clear();
        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPC", 1f);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            Reiniciar();
        }
    }


}




