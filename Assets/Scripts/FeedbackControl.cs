using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackControl : MonoBehaviour
{

    public int idButton;
    private float lightinstensity;
    public Light Llum;
    public bool Desactivate;
    public bool desactivating;
    public AudioClip buttonclick;
    public SimonManager controlador;

    /*Color baseColor;
    Renderer renderer_;
    Material mat;
    float emission;
    */

    // Start is called before the first frame update
    void Start()
    {
        lightinstensity = Llum.intensity;
        

        
    }

    public void ActivateButton()
    {
        desactivating = false;
        Desactivate = false;
        Llum.intensity = lightinstensity;
        Llum.gameObject.SetActive(true);

        //Llamar al manager para decirle que hemos hecho click a éste botón

        if (controlador.turnoPlayer)
        {
            controlador.ClickUsuario(idButton);

        }
        
        AudioSource.PlayClipAtPoint(buttonclick, Vector3.zero, 1.0f);

        Invoke("desactivarCubo", 0.1f);

    }

    public void desactivarCubo()
    {
        desactivating = true;

    }

    // Update is called once per frame
    void Update()
    {

        if(desactivating && !Desactivate)
        {
            Llum.intensity = Mathf.Lerp(Llum.intensity, 0, 0.065f); 

        }

        if (Llum.intensity <= 0.02)
        {
            Llum.intensity = 0;
            Desactivate = true;
        }
        
    }

    public void OnMouseDown()
    {
        print(name);
        ActivateButton();
    }

}
