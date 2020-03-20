using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiMenu : MonoBehaviour
{
    public GameObject pointsToWin;
    public GameObject multiplayer;
    public GameObject background;
    public Sprite[] fondos;
    public GameObject backgroundImage;
    public void StarGame()
    {
        Debug.Log("Inicia el juego");
        SceneManager.LoadScene("pong");
        
    }

    public void SetMultiplayer()
    {
        bool mp = multiplayer.GetComponent<Toggle>().isOn;
        Debug.Log("Multijugador: " + mp);
        gameObject.SendMessage("setMP", mp);
    }

    public void SetPointsToWin()
    {
        int points = pointsToWin.GetComponent<Dropdown>().value*2+1;
        Debug.Log("You need "+points+ " to win.");
        gameObject.SendMessage("setPTW", points);

    }

    public void SetBackground()
    {
        int bg = background.GetComponent<Dropdown>().value;
        backgroundImage.GetComponent<Image>().sprite = fondos[bg];
        Debug.Log("El background seleccionado es el: " + bg);
        gameObject.SendMessage("setBG", bg);
    }


}
