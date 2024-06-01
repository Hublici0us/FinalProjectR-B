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
        //gameManager.evolutionPanel.SetActive(false);
        Debug.Log("health: " + player.healthRegen);
    }

    public void IncreaseSpeed()
    {
        player.speed += 10;
        //gameManager.evolutionPanel.SetActive(false);
        Debug.Log("Speed: " + player.speed);
    }

    public void IncreaseDamage()
    {
        player.damageMod += 10;

        Debug.Log("Damage Mod: " + player.damageMod);

    }

    public void IncreaseMaxHealth()
    {
        player.maxHealth += 10;
        Debug.Log("max health: " + player.maxHealth);
        //gameManager.evolutionPanel.SetActive(false);
    }
}
