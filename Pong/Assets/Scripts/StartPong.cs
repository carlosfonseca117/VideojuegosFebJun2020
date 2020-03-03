using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPong : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb2D;
    public bool destroying;
    // Start is called before the first frame update
    void Start()
    {
        inicia();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ParedI")
        {
            PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2")+1);
            Debug.Log("Jugador 1: " + PlayerPrefs.GetInt("Score1") + "Jugador 2: " + PlayerPrefs.GetInt("Score2"));
            if (!destroying)
                inicia();
            else
                Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ParedD")
        {
            PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1") + 1);
            Debug.Log("Jugador 1: " + PlayerPrefs.GetInt("Score1") + "Jugador 2: " + PlayerPrefs.GetInt("Score2"));
            if (destroying)
                inicia();
            else
                Destroy(gameObject);
        }
        
    }

    private void inicia()
    {

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.position = new Vector2(0, 0);
        rb2D.velocity = new Vector2(0, 0);
        rb2D.AddForce(new Vector2(Random.value * speed, Random.value * speed), ForceMode2D.Impulse);
    }
}
