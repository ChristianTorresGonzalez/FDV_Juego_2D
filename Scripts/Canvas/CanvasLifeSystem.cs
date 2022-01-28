using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLifeSystem : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start() {

    }

    public void SetMaxHealth()
    {
        slider.value = slider.maxValue;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health, int maxHits)
    {
        health = (health * 100) / maxHits;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
