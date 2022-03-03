using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public GameObject PlayerArt;
    public GameObject SpeechBubbleArt;
    public static float playerTimer = 0f;
    public static float incrementValue = .001f;
    public static bool isTalking = false;
    public Animator animator;

    void Start() {
        PlayerArt.SetActive(true);
        SpeechBubbleArt.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update(){
        if (Input.GetKey("space") && Timer.gameTime > 0){
            isTalking = true;
            SpeechBubbleArt.SetActive(true);
            playerTimer += incrementValue;
            animator.SetBool("Chattering", true);
        } else {
            isTalking = false;
            SpeechBubbleArt.SetActive(false);
            animator.SetBool("Chattering", false);

        }
    }
}
