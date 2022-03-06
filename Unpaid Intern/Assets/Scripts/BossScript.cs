using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BossScript : MonoBehaviour
{
    // public GameObject distractedBossArt;
    // public GameObject focusedBossArt;
    public GameObject curiousBossArt;
    public static bool isDistracted = true;
    public Animator animator;

    private int progressBarFillTime = 10; //has a bit of a buffer
    private int gameTime;
    private List<int> distractedSegments = new List<int> ();
    private List<int> focusedSegments = new List<int> ();
    
    void Start()
    {
        StopAllCoroutines();
        gameTime = 30;
        Debug.Log("Game time is : " + gameTime);
        progressBarFillTime = 10;
        animator = GetComponentInChildren<Animator>();
        // distractedBossArt.SetActive(true);
        // focusedBossArt.SetActive(false);
        curiousBossArt.SetActive(false);
        List<int> times = pickSegments();
        for (int i = 0; i < times.Count; i++){
            Debug.Log(times[i]);
        }
        //shuffle segment lists
        times.Shuffle();
        //start boss
        StartCoroutine(moveBoss(times));

    }
    List<int> pickSegments(){
        //distracted time
        int distractedTimeLeft = progressBarFillTime;
        while (distractedTimeLeft > 2){
            int randomNum = (int) Random.Range(1, 2);
            distractedSegments.Add(randomNum);
            distractedTimeLeft -= randomNum;
        }
        if (distractedTimeLeft > 0){
            distractedSegments.Add(distractedTimeLeft);
        }      
        Debug.Log("Done with first part");
        //focused time
        int focusedTimeLeft = gameTime - progressBarFillTime;
        Debug.Log("Focused time:" + focusedTimeLeft );
        while (focusedTimeLeft > 2){
            int randomNum = (int) Random.Range(-2, -1);
            Debug.Log("Adding " + randomNum);
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
                // focusedBossArt.SetActive(false);
                // distractedBossArt.SetActive(true);
                animator.SetBool("Turn", true);
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
                // distractedBossArt.SetActive(false);
                // focusedBossArt.SetActive(true);
                animator.SetBool("Turn", false);
                isDistracted = false;
                yield return new WaitForSeconds(times[i] * -1);
            }
        }

    }

    void Update(){
        if (Timer.win) {
            animator.SetBool("Win",true);
        }
        
        if (Timer.lose) {
            animator.SetBool("Caught",true);
        }

    }
}