using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text textBox;
    public static float timer;
    public static bool timeStarted = false;

    void Update()
    {
        timer += Time.deltaTime;

        textBox.text = timer.ToString();

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        textBox.text = niceTime;

    }
}
