using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    public int speed;
    private float move;
    private bool upperLimit;
    private bool lowerLimit;
    private float size;
    public bool isSecondPlayer;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        /*move = Input.GetAxis("Vertical");
        if (upperLimit && move < 0)
            upperLimit = false;
        if (lowerLimit && move > 0)
            lowerLimit = false;
        if (!upperLimit && !lowerLimit)
            transform.position += new Vector3(0, move * speed);*/
        if(!isSecondPlayer)
            move = Input.GetAxis("Vertical");
        else
            move = Input.GetAxis("Vertical2");
        if (upperLimit && move < 0)
            upperLimit = false;
        if (lowerLimit && move > 0)
            lowerLimit = false;
        if (!upperLimit && !lowerLimit)
            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x,gameObject.GetComponent<Rigidbody2D>().position.y+move));
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Techo")
        {
            upperLimit = true; 
            transform.position = new Vector3(transform.position.x, collision.transform.position.y - size);
        }
            
        if (collision.tag == "Suelo")
        {
            lowerLimit = true;
            transform.position = new Vector3(transform.position.x, collision.transform.position.y + size);
        }
            
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Techo")
        {
            upperLimit = true;
            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x, collision.gameObject.GetComponent<Rigidbody2D>().position.y - size));
        }
        if (collision.gameObject.tag == "Suelo")
        {
            lowerLimit = true;
            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x, collision.gameObject.GetComponent<Rigidbody2D>().position.y + size));
        }
    }

    public void setSP()
    {
        isSecondPlayer = true;
    }
}
