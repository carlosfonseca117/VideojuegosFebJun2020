using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPong : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb2D;
    public bool destroying;
    public AudioSource audioRebotar;
    public AudioSource audioHit;
    // Start is called before the first frame update
    void Start()
    {
        inicia();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioRebotar.Play(); 
        }
        if(collision.gameObject.tag=="ParedI")
        {
            PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2")+1);
            
            gameObject.GetComponent<ValoresJuego>().setPP2(gameObject.GetComponent<ValoresJuego>().getPP2()+1);
            Debug.Log(gameObject.GetComponent<ValoresJuego>().getPP2());
            audioHit.Play();
            if (gameObject.GetComponent<ValoresJuego>().getPP2() == gameObject.GetComponent<ValoresJuego>().getPTW())
            {
                SceneManager.LoadScene("Menu");
            }
            if (!destroying)
                inicia();
            else
                Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ParedD")
        {
            PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1") + 1);
            Debug.Log("Jugador 1: " + PlayerPrefs.GetInt("Score1") + "Jugador 2: " + PlayerPrefs.GetInt("Score2"));
            gameObject.GetComponent<ValoresJuego>().setPP1(gameObject.GetComponent<ValoresJuego>().getPP1()+1);
            audioHit.Play();
            if (gameObject.GetComponent<ValoresJuego>().getPP2() == gameObject.GetComponent<ValoresJuego>().getPTW())
            {
                SceneManager.LoadScene("Menu");
            }
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
