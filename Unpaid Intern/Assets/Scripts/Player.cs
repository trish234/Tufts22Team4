using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // public GameObject PlayerArt;
    public Animator animator;
    public GameObject SpeechBubbleArt;
    public static float playerTimer = 0f;
    public static float incrementValue = .0004f;
    public static bool isTalking = false;

    void Start() {
        playerTimer = 0f;
        // PlayerArt.SetActive(true);
        animator = GetComponentInChildren<Animator>();
        SpeechBubbleArt.SetActive(false);
    }

    void Update(){
        if (Input.GetKey("space") && Timer.gameTime > 0){
            animator.SetBool("Turn", true);
            isTalking = true;
            SpeechBubbleArt.SetActive(true);
            playerTimer += incrementValue;
        } else {
            isTalking = false;
            animator.SetBool("Turn", false);
            SpeechBubbleArt.SetActive(false);
        }
    }
}
