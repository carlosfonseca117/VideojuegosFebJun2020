using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    public GameObject pointsToWin;
    public GameObject multiplayer;
    public GameObject background;
    public void StarGame()
    {
        Debug.Log("Inicia el juego");
    }

    public void SetMultiplayer()
    {
        bool mp = multiplayer.GetComponent<Toggle>().isOn;
        Debug.Log("Multijugador: " + mp);
    }

    public void SetPointsToWin()
    {
        int points = pointsToWin.GetComponent<Dropdown>().value*2+1;
        Debug.Log("You need "+points+ " to win.");

    }

    public void SetBackground()
    {
        int bg = background.GetComponent<Dropdown>().value;
        Debug.Log("El background seleccionado es el: " + bg);
    }


}
