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
    public bool gameoverButton;
    public GameObject restartText;


    public int Contador;
    public int ContadorUsuario;
    public int NivelActual;

    [Range(0.1f, 2f)]
    public float Velocidad;
    public AudioSource gameover;

    //public Slider sliderVel;
    //public Text SliderText;
    //public Text gameOverText;
    //public Text Nivel;


    // Start is called before the first frame update


 


    private void Start()
    {
        StartCoroutine(WaitFirstGame());
       

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
            restartText.SetActive(true);
            gameover.Play();
            print("Game Over");
            GameOver();
            gameoverButton = true;
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

        if (gameoverButton)
        {
            Contador = 0;
            restartText.SetActive(false);
            ContadorUsuario = 0;
            NivelActual = 0;
            ListaAleatoria.Clear();
            LlenarListaAleatoria();
            turnoPc = true;
            Invoke("TurnoPC", 1f);
            gameoverButton = false;
        }
      

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            Reiniciar();
        }
    }


    private IEnumerator WaitFirstGame()
    {

        yield return new WaitForSeconds(3);
        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPC", 0.5f);
    }


}




