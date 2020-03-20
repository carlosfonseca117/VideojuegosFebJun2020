using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private bool muliplayer;
    public GameObject p1;
    public GameObject barraEnemiga;
    public GameObject player2Prefab;
    private GameObject player2;
    private GameObject pelota;
    public GameObject prefabPelota;
    public GameObject BackGround;
    public Sprite[] background;
    public Sprite[] ball;
    public Sprite[] b1;
    public Sprite[] b2;
    
    // Start is called before the first frame update
    void Start()
    {
        
        p1.GetComponent<SpriteRenderer>().sprite = b1[GetComponent<ValoresJuego>().getBG()];
        muliplayer = gameObject.GetComponent<ValoresJuego>().getMP();
        if (muliplayer)
        {
            player2 = Instantiate(player2Prefab, new Vector2(9, 0), Quaternion.Euler(0, 0, 90));
            player2.GetComponent<SpriteRenderer>().sprite = b2[GetComponent<ValoresJuego>().getBG()];
            player2.GetComponent<Barra>().isSecondPlayer = gameObject.GetComponent<ValoresJuego>().getMP();
            //player2.SendMessage("setSP");
        }   
        else
        {
            barraEnemiga = Instantiate(barraEnemiga);
            barraEnemiga.GetComponent<SpriteRenderer>().sprite = b2[GetComponent<ValoresJuego>().getBG()];
        }
        BackGround.GetComponent<SpriteRenderer>().sprite = background[GetComponent<ValoresJuego>().getBG()];
        if (GetComponent<ValoresJuego>().getBG() == 2)
        {
            p1.transform.localScale = new Vector3(1, 1, p1.transform.localScale.z);
            barraEnemiga.transform.localScale = new Vector3(1, 1, barraEnemiga.transform.localScale.z);
        }

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
            pelota.GetComponent<SpriteRenderer>().sprite = ball[GetComponent<ValoresJuego>().getBG()];
        }
    }

}
