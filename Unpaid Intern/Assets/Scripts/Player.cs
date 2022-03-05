using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public GameObject PlayerArt;
    public GameObject SpeechBubbleArt;
    public static float playerTimer = 0f;
    public static float incrementValue = .001f;
    public static bool isTalking = false;

    void Start() {
        playerTimer = 0f;
        PlayerArt.SetActive(true);
        SpeechBubbleArt.SetActive(false);
    }

    void Update(){
        if (Input.GetKey("space") && Timer.gameTime > 0){
            isTalking = true;
            SpeechBubbleArt.SetActive(true);
            playerTimer += incrementValue;
        } else {
            isTalking = false;
            SpeechBubbleArt.SetActive(false);
        }
    }
}
