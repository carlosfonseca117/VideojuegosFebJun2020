using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public bool muliplayer;
    public GameObject barraEnemiga;
    public GameObject player2Prefab;
    private GameObject player2;
    private GameObject pelota;
    public GameObject prefabPelota;
    // Start is called before the first frame update
    void Start()
    {
        if (muliplayer)
        {
            player2 = Instantiate(player2Prefab, new Vector2(9, 0), Quaternion.Euler(0, 0, 90));
            player2.SendMessage("setSP");
        }   
        else
            Instantiate(barraEnemiga);
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("Score2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && pelota == null)
        {
            Debug.Log("Lanza pelota");
            pelota = Instantiate(prefabPelota);
        }
    }

}
