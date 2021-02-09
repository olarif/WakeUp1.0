using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinMenuManager : MonoBehaviour
{

    public TextMeshProUGUI timeScore;
    public TextMeshProUGUI coinScore;

    public int coins;
    public float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coins = GameManager1.score;
        time = GameManager1.timer;

        timeScore.text = time.ToString();
        coinScore.text = coins.ToString();

        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeScore.text = niceTime;

    }


}
