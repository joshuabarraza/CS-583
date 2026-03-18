using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {
    public AppleTree appleTree;
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();

        slider.minValue = 5f;
        slider.maxValue = 40f;
        slider.value = 10f;

        SetDifficulty(slider.value);
        slider.onValueChanged.AddListener(SetDifficulty);
    }

    void SetDifficulty(float value) {
        float direction = Mathf.Sign(appleTree.speed);
        appleTree.speed = direction * value;
    }
}