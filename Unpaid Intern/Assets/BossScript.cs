using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BossScript : MonoBehaviour
{
    public GameObject distractedBossArt;
    public GameObject focusedBossArt;
    public GameObject curiousBossArt;
    public static bool isDistracted = true;

    private int progressBarFillTime = 11 + 4; // + 4s buffer time
    private int gameTime = 20;
    //private int rangeMax = 3000;
    private List<int> distractedSegments;
    private List<int> focusedSegments ;

    void Start()
    {
        focusedBossArt.SetActive(false);
        curiousBossArt.SetActive(false);
        List<int> times = pickSegments();
    }
    List<int> pickSegments(){
        //distracted time
        int distractedTimeLeft = progressBarFillTime;
        while (distractedTimeLeft > 3){
            int randomNum = (int) Random.Range(1, 3);
            distractedSegments.Add(randomNum);
            distractedTimeLeft -= randomNum;
        }
        if (distractedTimeLeft > 0){
            distractedSegments.Add(distractedTimeLeft);
        }      
        
        //focused time
        int focusedTimeLeft = gameTime - progressBarFillTime;
        while (focusedTimeLeft > 3){
            int randomNum = (int) Random.Range(-3, -1);
            focusedSegments.Add(randomNum);
            focusedTimeLeft += randomNum;
        }
        if (focusedTimeLeft > 0){
            focusedSegments.Add(focusedTimeLeft);
        }
        
        // concat lists
        return distractedSegments.Concat(focusedSegments).ToList();

    }
}
    // Start is called before the first frame update
    /* void Start()
    {
        focusedBossArt.SetActive(false);
        curiousBossArt.SetActive(false);
        StartCoroutine(changeFocus());
    }

    IEnumerator changeFocus(){
       while (true){
           if (randomNum == 45){
                if (isDistracted) {
                    curiousBossArt.SetActive(true);
                    yield return new WaitForSeconds(2);
                    distractedBossArt.SetActive(false);
                    curiousBossArt.SetActive(false);
                    focusedBossArt.SetActive(true);
                    isDistracted = false;
                } else {
                    yield return new WaitForSeconds(2);
                    distractedBossArt.SetActive(true);
                    focusedBossArt.SetActive(false);
                    isDistracted = true;
                }
           }
           RandomMaker();
           yield return null;
       }
    }
    public void RandomMaker(){
        randomNum = Random.Range(0, rangeMax);
    }
} */
