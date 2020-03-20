using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    public GameObject animator;
    private Animator controller;
    public float caminar;
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        controller = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        caminar = Input.GetAxis("Horizontal");
        caminar = Mathf.Abs(caminar);
        controller.SetFloat("walk", caminar);
        controller.SetBool("jump", jump);
    }
}
