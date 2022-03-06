using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject timeText;
    public GameObject gameOverWinText;
    public GameObject gameOverLoseText;
    public GameObject replayBtn;
    public static int gameTime = 30;
    public static float gameTimer = 0f;
    public static bool win;
    public static bool lose;

    void Start(){
        gameTime = 30;
        replayBtn.SetActive(false);
        gameOverWinText.SetActive(false);
        gameOverLoseText.SetActive(false);
        UpdateTime();
    }
    
    void FixedUpdate(){
        // player gets caught before timer ends and loses
        if (Player.isTalking && !BossScript.isDistracted) {
            gameOverLoseText.SetActive(true);
            lose = true;
            gameTime = 0;
        }

        // player fills bar before timer ends and wins
        if (ProgressBar.targetProgress >= 1) {
            gameOverWinText.SetActive(true);
            win = true;
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
                replayBtn.SetActive(true);
                win = true;
            } else {
                gameOverLoseText.SetActive(true);
                replayBtn.SetActive(true);
                lose = true;
            }
        }
    }

    public void UpdateTime(){
        Text theTime = timeText.GetComponent<Text>();
        theTime.text = "" + gameTime;
    }
}
