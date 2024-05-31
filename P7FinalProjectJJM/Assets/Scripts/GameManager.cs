using System.Collections;
using System.Collections.Generic;
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
    public bool gameOver;


    [Header("Enemy Related")]
    public GameObject[] enemies;
    private int enemiesToSpawn = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sceneManager = GameObject.Find("GameManager").GetComponent<SceneStuff>();
        pauseEmpty.SetActive(false);
        gameOverEmpty.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        if(gameOver == true)
        {
            GameOver();
        }

        if(gameOver == false)
        {
            Time.timeScale = 1.0f;
        }
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

    public void ReturnButton()
    {
        pauseEmpty.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver()
    {
        gameOverEmpty.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemies();
                yield return new WaitForSeconds(1f);
            }

            evolutionPanel.SetActive(true );


        }
    }

    void SpawnEnemies()
    {
        int enemyIndex = Random.Range(0, enemies.Length);

      //  Instantiate(enemies[enemyIndex], Vector3.zero, Quaternion.identity);
    }

    public void UpdateHealthUI()
    {
        playerController.healthSlider.value = playerController.health;
        playerController.healthText.text = ($"{playerController.health}");
    }
}
