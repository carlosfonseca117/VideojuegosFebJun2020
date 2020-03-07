using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody2D rb;
    private float limiteIzq, limiteDer, actual;
    private int contador;
    public int velocidad;
    public GameObject balaE;
    public int contadorD;
    public int disparo;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        actual = rb.position.x;
        limiteIzq = actual - 1;
        limiteDer = actual + 1;
    }

    // Update is called once per frame
    void Update()
    {
        contador++;
        contadorD++;
        if (contadorD == disparo)
        {
            Instantiate(balaE, new Vector3(rb.position.x, rb.position.y - 1), new Quaternion(0, 0, 0, 0));
            contadorD = 0;
        }
        if (actual < limiteDer && contador == velocidad)
        {
            actual++;
            contador = 0;
            rb.position = new Vector3(actual, rb.position.y);
           

        }
        if (actual == limiteDer && contador == velocidad)
        {
            actual = actual - 2;
            contador = 0;
            rb.position = new Vector3(actual, rb.position.y);
            //Instantiate(balaE, new Vector3(rb.position.x, rb.position.y - 1), new Quaternion(0, 0, 0, 0));
        }


    }
}
