using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // public GameObject PlayerArt;
    public GameObject SpeechBubbleArt;
    public static float playerTimer = 0f;
    public static float incrementValue = .001f;
    public static bool isTalking = false;
    public Animator animator;

    void Start() {
        // PlayerArt.SetActive(true);
        SpeechBubbleArt.SetActive(false);
        animator = GetComponentInChildren<Animator>();
    }

    void Update(){
        if (Input.GetKey("space") && Timer.gameTime > 0){
            animator.SetBool("Chattering", true);
            isTalking = true;
            SpeechBubbleArt.SetActive(true);
            playerTimer += incrementValue;
        } else {
            animator.SetBool("Chattering", false);
            isTalking = false;
            SpeechBubbleArt.SetActive(false);

        }
    }
}
