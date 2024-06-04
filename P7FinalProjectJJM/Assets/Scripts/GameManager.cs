using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SceneStuff sceneManager;

    PlayerController playerController;

    [Header("UI")]
    public GameObject pauseEmpty;
    public GameObject gameOverEmpty;
    public GameObject evolutionPanel;
    public TextMeshProUGUI waveStartText;
    public bool gameOver;


    [Header("Enemy Related")]
    public GameObject[] enemies;
   
    private WaveSpawner waveSpawner;

    //WaveManagement
    public bool timerOn;
    private float timeTillWave = 10;
    public bool firstWave = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sceneManager = GameObject.Find("GameManager").GetComponent<SceneStuff>();
        pauseEmpty.SetActive(false);
        gameOverEmpty.SetActive(false);
        gameOver = false;
        timerOn = true;
        waveSpawner = GameObject.Find("GameManager").GetComponent<WaveSpawner>();
        //to make sure evolution panel does not turn on at the beginning
        firstWave = true;
    }

    // Update is called once per frame
    void Update()
    { 
        PauseGame(); //always check for escape to pause game
        if(gameOver == true)
        {
            GameOver();
        }

        if(gameOver == false) //time is always at 1 if game is still going on
        {
            Time.timeScale = 1.0f;
        }
        
        CountDownToWave();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            pauseEmpty.SetActive(true);
            Time.timeScale = 0;
        }
    }
    //resume the game
    public void ReturnButton()
    {
        pauseEmpty.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
    }
    //gameover screen becomes active
    public void GameOver()
    {
        gameOverEmpty.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    /*
    public void UpdateHealthUI()
    {
        playerController.healthSlider.value = playerController.health;
        playerController.healthText.text = ($"{playerController.health}");
    }*/
    //countdown timer that shows the time left till the next wave
    public void CountDownToWave()
    {
        if(timerOn == true)
        {
            timeTillWave -= Time.deltaTime;
            waveStartText.text = ("Wave Starts In: " + Mathf.FloorToInt(timeTillWave));
            if(timeTillWave < 1)
            {
                timerOn = false;

                timeTillWave = 30;
                waveSpawner.WaveStart();
                firstWave = false;
            }

        }
    }
}
