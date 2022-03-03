using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // public GameObject distractedBossArt;
    // public GameObject focusedBossArt;
    // public GameObject curiousBossArt;
    public static bool isDistracted = true;
    private int rangeMax = 3000;
    private int randomNum;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // focusedBossArt.SetActive(false);
        // curiousBossArt.SetActive(false);
        animator = GetComponentInChildren<Animator>();
    }
    
     void Update() {
        StartCoroutine(changeFocus());

    }

    IEnumerator changeFocus(){
       while (true){
           if (randomNum == 45){
                if (isDistracted) {
                    // curiousBossArt.SetActive(true);
                    yield return new WaitForSeconds(2);
                    animator.SetBool("Turn", false);
                    // distractedBossArt.SetActive(false);
                    // curiousBossArt.SetActive(false);
                    // focusedBossArt.SetActive(true);
                    

                    isDistracted = false;
                } else {
                    yield return new WaitForSeconds(2);
                    // distractedBossArt.SetActive(true);
                    animator.SetBool("Turn", true);
                    // focusedBossArt.SetActive(false);
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
