using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraEnemiga : MonoBehaviour
{
    private float size;
    public GameObject pelota;
    public GameObject techo;
    public GameObject suelo;
    private float move;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x / 2;
        techo = GameObject.FindGameObjectWithTag("Techo");
        suelo = GameObject.FindGameObjectWithTag("Suelo");
    }

    // Update is called once per frame
    void Update()
    {
        if(pelota==null)
        {
            pelota = GameObject.FindGameObjectWithTag("Pelota");
        }
        if(pelota!=null)
        {
            move = pelota.transform.position.y;

            if (move > suelo.transform.position.y + size && move < techo.transform.position.y - size)
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x, move));
        }
        
    }
}
