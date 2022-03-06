using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    
    private Slider slider;
    public float fillSpeed = 0.08f;
    public static float targetProgress;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start() {
        targetProgress = 0;
        slider.value = 0;
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
