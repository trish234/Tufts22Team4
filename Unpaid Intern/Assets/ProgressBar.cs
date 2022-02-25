using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    
    private Slider slider;
    public float fillSpeed = 0.1f;
    public static float targetProgress = 0;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start() {
    }

    void Update() {
        if (slider.value < Player.playerTimer) {
            IncrementProgress(Player.incrementValue); 
        }

        if (slider.value < targetProgress) {
            slider.value += fillSpeed * Time.deltaTime;
        }
    }

    public void IncrementProgress(float newProgress) {
        targetProgress = slider.value + newProgress;
    }
}
