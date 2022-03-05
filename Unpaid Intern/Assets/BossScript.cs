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

    private int progressBarFillTime = 11 + 2; // + 2s buffer time
    private int gameTime = Timer.gameTime;
    private List<int> distractedSegments = new List<int> ();
    private List<int> focusedSegments = new List<int> ();

    void Start()
    {
        distractedBossArt.SetActive(true);
        focusedBossArt.SetActive(false);
        curiousBossArt.SetActive(false);
        List<int> times = pickSegments();
        for (int i = 0; i < times.Count; i++){
            Debug.Log(times[i]);
        }
        //shuffle segment lists
        times = times.OrderBy( x => Random.value ).ToList();
        //start boss
        StartCoroutine(moveBoss(times));

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
    IEnumerator moveBoss(List<int> times) {
         //loop through times
        
        for (int i = 0; i < times.Count; i++){
            // if we have a positive time, do the question mark at end
            if (times[i] > 0){ //distracted boss
                Debug.Log("In distracted mode");
                focusedBossArt.SetActive(false);
                distractedBossArt.SetActive(true);
                isDistracted = true;
                if (i + 1 < times.Count && times[i + 1] < 0){
                    yield return new WaitForSeconds(times[i] - 1);
                    curiousBossArt.SetActive(true);
                    yield return new WaitForSeconds(1);
                    curiousBossArt.SetActive(false);
                } else {
                    yield return new WaitForSeconds(times[i]);
                }
                
            } else { // focused boss
                Debug.Log("In focused mode");
                distractedBossArt.SetActive(false);
                focusedBossArt.SetActive(true);
                isDistracted = false;
                yield return new WaitForSeconds(times[i] * -1);
            }
        }

    }
}