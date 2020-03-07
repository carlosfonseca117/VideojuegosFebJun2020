using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navecita : MonoBehaviour
{
    Rigidbody2D navecita;
    public GameObject bala;
    GameObject balaE;
    float movimiento;
    public float speed;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        navecita = gameObject.GetComponent<Rigidbody2D>();
        balaE = null;
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = Input.GetAxis("Horizontal") * speed;
        navecita.MovePosition(new Vector2(navecita.position.x + movimiento, navecita.position.y));
        if (Input.GetAxis("Jump") == 1.0&&balaE==null)
        {
           balaE= Instantiate(bala, new Vector3(navecita.position.x,navecita.position.y+1,bala.transform.position.z),new Quaternion(0,0,0,0));

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Choque contra " + collision.gameObject.tag);
        if(collision.gameObject.tag == "balitaEnemiga")
        {
            //vida--;
            //if (vida == 0)
                Destroy(gameObject);
        }
    }

}
