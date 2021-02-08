using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    public Vector2 lastCheckPointPos;
   // public static GameObject gm;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndingWait;
    private WaitForSeconds Onesec;
    private float m_StartDelay = 3f;
    private float m_EndDelay = 3f;
    private bool GamePause;
    private int score;
    public TextMeshProUGUI text;

    public static bool GameOver;
    public GameObject m_canvas;
    public PlayerMovement player;
    public Text textBox;
    public static float timer;
    public static bool timeStarted = false;
    //------------------
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndingWait = new WaitForSeconds(m_EndDelay);
        Onesec = new WaitForSeconds(1f);
        StartCoroutine(GameLoop());
    }
    private void Update()
    {
        TimerUpdate();
        PauseFunction();
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
    }

    private IEnumerator GameLoop()
    {
        {
            yield return StartCoroutine(RoundStarting());
            yield return StartCoroutine(RoundPlaying());
            yield return StartCoroutine(RoundEnding());
        }
    }
    private IEnumerator RoundStarting()
    {
        
        timer = 0;
        
        score = 0;
       
        yield return m_StartWait;
    }
    private IEnumerator RoundPlaying()
    {
        
        while (!GameOver)
        {
            yield return null;
        }

    }
    private IEnumerator RoundEnding()
    {
        yield return m_EndingWait;
        yield return null;
    }
    //-------------------------------------------------

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
    }
    public void TimerUpdate()
    {
        timer += Time.deltaTime;

        textBox.text = timer.ToString();

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        textBox.text = niceTime;
    }
    public void PauseFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/UI/OpenMenu", gameObject);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        //Destroy(GameObject.FindGameObjectWithTag("GM"));
        Application.LoadLevel(Application.loadedLevel);
        Resume();
        //SceneManager.LoadScene("1-1 A Clockwork");
    }

    public void LoadMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/UI/OpenMenu", gameObject);
        SceneManager.LoadScene("Menu");
        Resume();
        //Destroy(GameObject.FindGameObjectWithTag("GM"));
        SceneManager.UnloadSceneAsync("1-1 A Clockwork");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
