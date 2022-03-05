using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject timeText;
    public GameObject gameOverWinText;
    public GameObject gameOverLoseText;
    public static int gameTime;
    public static float gameTimer = 0f;

    void Start(){
        gameTime = 30;
        gameOverWinText.SetActive(false);
        gameOverLoseText.SetActive(false);
        UpdateTime();
    }
    
    void FixedUpdate(){
        // player gets caught before timer ends and loses
        if (Player.isTalking && !BossScript.isDistracted) {
            gameOverLoseText.SetActive(true);
            gameTime = 0;
        }

        // player fills bar before timer ends and wins
        if (ProgressBar.targetProgress >= 1) {
            gameOverWinText.SetActive(true);
            gameTime = 0;
        }

        if (gameTime > 0) {
            gameTimer += 0.015f;
            if (gameTimer >= 1f && gameTime > 0){
                gameTime -= 1;
                gameTimer = 0;
                UpdateTime();
            }
        } else {
            // timer ends and player wins/loses
            if (ProgressBar.targetProgress >= 1) {
                gameOverWinText.SetActive(true);
            } else {
                gameOverLoseText.SetActive(true);
            }
        }
    }

    public void UpdateTime(){
        Text theTime = timeText.GetComponent<Text>();
        theTime.text = "" + gameTime;
    }
}
