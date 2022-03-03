using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Chattering", false);
    }

    void Update() {
        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Chattering", true);

        }
    }

    // Update is called once per frame
}
