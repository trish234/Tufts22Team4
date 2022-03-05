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
            animator.SetBool("Turn", true);
            isTalking = true;
            SpeechBubbleArt.SetActive(true);
            playerTimer += incrementValue;
        } else {
            animator.SetBool("Turn", false);
            isTalking = false;
            SpeechBubbleArt.SetActive(false);

        }
        if (isTalking && !BossScript.isDistracted) {
            animator.SetBool("Caught", true);
            SpeechBubbleArt.SetActive(false);

        }

        if (ProgressBar.targetProgress >= 1) {
            animator.SetBool("Win", true);
         }

        // if (ProgressBar.targetProgress < 1) {
        //     animator.SetBool("Caught", true);
        // }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public Animator animator;
//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponentInChildren<Animator>();
//     }

//     void Update() {
//         if(Input.GetKey("space")) {
//             animator.SetBool("Chattering", true);
//         }
//         else {
//             animator.SetBool("Chattering", false);
//         }
//     }

//     // Update is called once per frame
// }



