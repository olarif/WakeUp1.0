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
    private float m_StartDelay = 1f;
    private float m_EndDelay=0.5f;
    public static int score;
    private bool isDead;
    public TextMeshProUGUI text;

    public static bool GameOver=false;
    public GameObject m_canvas;
    public PlayerMovement player;
    public Text textBox;
    public static float timer;
    public static bool timeStarted = false;
    //------------------
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI,WinScreen,GameOverScreen;
    FMOD.Studio.Bus Master;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/SoundEffects");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
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
        Time.timeScale = 1f;
        timer = 0;
        
        score = 0;
        isDead = false;
        GameOver = false;
       
        yield return m_StartWait;
    }
    private IEnumerator RoundPlaying()
    {
        Debug.Log("GameRunning");
      
        while (!GameOver)
        {
           
            yield return null;
        }

    }
    private IEnumerator RoundEnding()
    {
        
        Debug.Log("GameOver");
        if (isDead)
            Sleep();
        else Win();

        yield return m_EndingWait;
        yield return null;
    }
    //-------------------------------------------------
    public void isGameOver(bool isAlive)
    {
       GameOver = true;
        if (isAlive)
        {
            isDead = false;
        }
        else
        {
            isDead = true;
        }
    }
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
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            WinScreen.SetActive(false);
            Time.timeScale = 1f;
            GameOver = false;
        }
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Win()
    {
        Master.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        WinScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Sleep()
    {
        Master.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene("1-1 A Clockwork");
    }

    public void LoadMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/UI/OpenMenu", gameObject);
        SceneManager.LoadScene("Menu");
        Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
