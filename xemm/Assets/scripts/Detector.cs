using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    public bool digging;
    public bool godown;
    public bool goleft;
    public bool goright;
    public GameObject piso;
    public GameObject character;
    private GameObject block;
    private BoxCollider2D coll;

    private void Start()
    {
        coll = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        godown = Input.GetKey(KeyCode.DownArrow);
        goleft = Input.GetKey(KeyCode.LeftArrow);
        goright = Input.GetKey(KeyCode.RightArrow);
        digging = Input.GetKeyDown(KeyCode.LeftControl);
        if(godown)
        {
            coll.offset = new Vector2(0, -.15f);
        }       
        if (goleft)
        {
            coll.offset = new Vector2(-1, 0);
        }      
        if (goright)
        {
            coll.offset = new Vector2(1, 0);
        }
        if (!goright && !goleft && !godown)
        {
            coll.offset = new Vector2(0, 0);
            if (block != null)
                block.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (godown && digging)
        {
            Destroy(block);
            piso.transform.position = new Vector3(piso.transform.position.x, piso.transform.position.y-1);
        }
        if (goleft && digging)
        {
            Destroy(block);
            character.transform.position = new Vector3(character.transform.position.x-1, character.transform.position.y);
        }
        if (goright && digging)
        {
            Destroy(block);
            character.transform.position = new Vector3(character.transform.position.x + 1, character.transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Bloque"))
        {
            if(block != null)
                block.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            block = collision.gameObject;
            block.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        Debug.Log("Yei choque contra: " + collision.gameObject.tag);
    }

}
