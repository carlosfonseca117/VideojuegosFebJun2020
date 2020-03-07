using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaE : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Respawn" || collision.gameObject.tag == "Player")
            Destroy(gameObject);

    }
}
