using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPlayerRevive : MonoBehaviour
{
    private GameObject reviveBar;
    private Slider slider;

    private void Awake() {
        reviveBar = GameObject.FindWithTag("ReviveBar");
        slider = reviveBar.GetComponent<Slider>();
    }

    public void InitializeRevive()
    {
        reviveBar.SetActive(false);
    }

    public void RevivePlayer(int reviveTime)
    {
        reviveBar.SetActive(true);

        StartCoroutine(RevivePlayerCanvas(reviveTime));
    }

    IEnumerator RevivePlayerCanvas(int reviveTime)
    {
        reviveTime *= 100;
        slider.maxValue = reviveTime;

        int counter = 0;
        while(counter <= reviveTime) {
            slider.value = counter;

            counter++;
            
            yield return new WaitForSeconds(0.01f);
        }

        reviveBar.SetActive(false);
    }
}
