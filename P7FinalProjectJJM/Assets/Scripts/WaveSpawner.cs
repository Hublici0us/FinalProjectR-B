using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class WaveSpawner : MonoBehaviour
{
    public int enemiesInScene = 0;
    private int enemyLimit = 5;
    private int enemiesSpawned;
    public bool evoOn;
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
                while (enemiesInScene < enemyLimit && enemiesSpawned < enemyLimit)
                {
                    SpawnEnemies();
                    enemiesInScene++;
                    enemiesRemainingText.text = "Enemies Remaining: " + enemiesInScene;
                    
                    
                }
                yield return new WaitForSeconds(2f);
                WaveEnd();
            }
        }
    }

    void SpawnEnemies()
    {


        int spawnPoint = Random.Range(0, spawningPoints.Length);

        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        enemiesSpawned++;

        Instantiate(enemyPrefabs[randomEnemy], spawningPoints[spawnPoint].transform.position, enemyPrefabs[randomEnemy].transform.rotation); 
    }

    public void WaveEnd()
    {
        if (enemiesInScene <=0)
        {
            StopCoroutine(WaveSpawn());
            waveNumber += 1;
            wavesCompleted += 1;
            enemyDamageMod += 10;
            enemyHpMod += 10;
            enemiesSpawned = 0;
            manager.evolutionPanel.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //manager.timerOn = true;
        }
        else 
        {

        }
    }
}
