using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject timeText;
    public GameObject gameOverWinText;
    public GameObject gameOverLoseText;
    public int gameTime = 10;
    public static float gameTimer = 0f;

    void Start(){
        gameOverWinText.SetActive(false);
        gameOverLoseText.SetActive(false);
        UpdateTime();
    }

    void FixedUpdate(){
        if (gameTime > 0) {
            gameTimer += 0.015f;
            if (gameTimer >= 1f && gameTime > 0){
                gameTime -= 1;
                gameTimer = 0;
                UpdateTime();
            }
        } else {
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
