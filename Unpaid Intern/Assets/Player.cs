using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        if(Input.GetKey("space")) {
            animator.SetBool("Chattering", true);
        }
        else {
            animator.SetBool("Chattering", false);
        }
    }

    // Update is called once per frame
}


