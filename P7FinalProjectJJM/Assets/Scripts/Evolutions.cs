using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolutions : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerController player;
    private GameManager gameManager;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseRegen()
    {
        player.healthRegen += 2;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.evolutionPanel.SetActive(false);

    }

    public void IncreaseSpeed()
    {
        player.speed += 10;
        gameManager.evolutionPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IncreaseDamage()
    {
        player.damageMod += 10;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.evolutionPanel.SetActive(false);

    }

    public void IncreaseMaxHealth()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player.maxHealth += 10;
        gameManager.evolutionPanel.SetActive(false);
    }
}
