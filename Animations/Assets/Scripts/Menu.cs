using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject toggle;
    public GameObject inputText;
    public GameObject dropdown;
    public GameObject emisorSonido;

    public bool playSound;

    private AudioSource source;


    public void Start()
    {
        source = emisorSonido.GetComponent<AudioSource>();
    }

    public void Jugar()
    {
        Debug.Log("Apretaste el boton de jugar");
        SceneManager.LoadScene("Scene2");
    }

    public void LeDisteClick()
    {
        bool activo = toggle.GetComponent<Toggle>().isOn;
        Debug.Log("Cambio de opcion en toggle es: "+ activo);
    }

    public void NombraTuMinero()
    {
        string nombre = inputText.GetComponent<InputField>().text;
        Debug.Log("El nombre de tu minero es: " + nombre);
    }

    public void SelecionaDificultad()
    {
        int dificultad = dropdown.GetComponent<Dropdown>().value;

        Debug.Log("Tu dificultad seleccionada es: " + dificultad);
    }

    public void Update()
    {
        if(playSound && !source.isPlaying)
            source.Play();
    }


}
