using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private int enemiesInScene = 0;
    private int enemyLimit = 5;
    public GameObject[] spawningPoints;
    public GameObject[] enemyPrefabs;

    private int wavesCompleted = 0;
    public int enemyDamageMod = 0;
    public int enemyHpMod = 0;

    public TextMeshProUGUI completedWaveText;
    public TextMeshProUGUI enemiesRemainingText;

    private GameManager manager;

    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        completedWaveText.text = "Waves Completed: " + wavesCompleted;
        WaveEnd();
    }

    public void WaveStart()
    {
        StartCoroutine(WaveSpawn());
    }
    IEnumerator WaveSpawn()
    {
        while (true)
        {
            for(int i = 0; i < waveNumber; i++)
            {
                while(enemiesInScene < enemyLimit)
                {
                    SpawnEnemies();
                    enemiesInScene++;
                    enemiesRemainingText.text = "Enemies Remaining: " + enemiesInScene;
                    enemyLimit *= waveNumber;
                    
                }
                yield return new WaitForSeconds(2f);
            }
        }
    }

    void SpawnEnemies()
    {
        int spawnPoint = Random.Range(0, spawningPoints.Length);

        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        

        Instantiate(enemyPrefabs[randomEnemy], spawningPoints[spawnPoint].transform.position, enemyPrefabs[randomEnemy].transform.rotation); 
    }

    public void WaveEnd()
    {
        if(enemiesInScene == 0 && manager.firstWave == false)
        {
            StopCoroutine(WaveSpawn());
            waveNumber += 1;
            wavesCompleted += 1;
            enemyDamageMod += 10;
            enemyHpMod += 10;
            manager.evolutionPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            manager.timerOn = true;
        }
    }
}
