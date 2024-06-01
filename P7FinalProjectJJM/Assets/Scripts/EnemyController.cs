using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public int enemyDamage;
    public float hitCooldown = 5;
    public int enemyHealth;
    public Slider enemyHealthSlider;

    public GameObject[] enemyDrops;

    private GameManager gManager;
    private WaveSpawner waveSpawner;
    Rigidbody enemyRb;

    public Weapon_Gun gunWeapon;
    private void Awake()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        waveSpawner = GameObject.Find("GameManager").GetComponent<WaveSpawner>();
    }
    void MoveToPlayer()
    {
        // code to move to player
        transform.LookAt(GameObject.Find("Player").transform);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

        //a timer for the hit cooldown so enemy cant instantly kill player
        hitCooldown -= Time.deltaTime;

        //measures distance to see if enemy is in range to hit player
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 2)
        {
            // code to attack player w/ cooldown
            if (hitCooldown < 0)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().TakeDamage(enemyDamage);
                hitCooldown = 5;
                gManager.UpdateHealthUI();
                stopFollowing();
            }
            else
            {
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void Update()
    {
        //EnemyDeath();
        EnemyHealthUI();
        EnemyMaxHealth();
    }

    /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    } */

    IEnumerator stopFollowing()
    {
        gameObject.transform.Translate(Vector3.zero);
        yield return new WaitForSeconds(1);
    }

    public void EnemyHealthUI()
    {
        enemyHealthSlider.value = enemyHealth;
    }

    public void enemyWaveUpdate()
    {
        enemyHealth += waveSpawner.enemyHpMod;
        enemyDamage += waveSpawner.enemyDamageMod;
    }

    public void EnemyMaxHealth()
    {
        enemyHealthSlider.value = enemyHealth;
    }

    /* uncomment code after weapons work. drops loot for the player.
     * public void EnemyDeath()
    {
        if (enemyHealth == 0)
        {
            int lootDrop = Random.Range(0, enemyDrops.Length);

            Instantiate(enemyDrops[lootDrop], enemyRb.position, enemyRb.rotation);


            Destroy(gameObject);
        }
    }*/
}
