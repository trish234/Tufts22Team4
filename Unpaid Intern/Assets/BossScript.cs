using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject distractedBossArt;
    public GameObject focusedBossArt;
    public bool isDistracted = true;
    public int rangeMax = 900;
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        focusedBossArt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomNum == 45){
            ChangeFocus();
        }
        RandomMaker();
    }
    void ChangeFocus(){
        isDistracted = !isDistracted;
        if (isDistracted) {
            focusedBossArt.SetActive(false);
            distractedBossArt.SetActive(true);
        } else {
            distractedBossArt.SetActive(false);
            focusedBossArt.SetActive(true);
        }
    }
    public void RandomMaker(){
        randomNum = Random.Range(0, rangeMax);
    }
}
