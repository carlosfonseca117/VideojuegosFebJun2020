using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorScript : MonoBehaviour
{

    private Animator animator;
    public float movimiento;
    public bool salto;
    public bool agachate;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("caminar",movimiento);
    }
}
