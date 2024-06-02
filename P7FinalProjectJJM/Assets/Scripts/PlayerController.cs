using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Player Info")]
    public float speed = 50f;
    public int health = 100;
    public int maxHealth = 100;
    public int healthRegen = 1;
    public int damageMod = 0;
    private float regenCoolDown = 3;
    public bool hasGun = false;

    Vector3 MovementDirection;
    public Transform orientation;
    Rigidbody playerRb;
    Animator animator;
    public AnimationClip knifeSwing;

    [Header("Player UI")]
    public UnityEngine.UI.Slider healthSlider;
    public TextMeshProUGUI healthText;

    [Header("Ground Check")]

    public float groundDrag = 5;
    public float playerHeight;
    public LayerMask whatIsGround;

    bool grounded;


    [Header("Weapons")]
    public List<GameObject> weapons;
    public int currentWeapon;
    public bool hasAWeapon;

    private GameManager gameManager;

    private void Awake()
    {

    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerRb.freezeRotation = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hasAWeapon = false;
        SetMaxHealth();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MovementDirection = orientation.forward * vertical + orientation.right * horizontal;

        playerRb.AddForce(MovementDirection.normalized * speed, ForceMode.Force);

    }

    void FixedUpdate()
    {
        PlayerMovement();
        PlayerAttack();
        CheckForWeapon();
        WeaponSelection();
    }

    void Update()
    {
        // ground checking: sends a raycast (invisible arrow tracker thingy) straight down from player position, if detects layer "whatIsGround" then applies drag.
        grounded = Physics.Raycast(gameObject.transform.position, Vector3.down, playerHeight + 0.2f, whatIsGround);

        if (!grounded)
        {
            if (speed > 40)
            {
                return;
            }
            else
            {
                speed--;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health -= 20;
        }
        SetHealth();

        if(health <= 0)
        {
            gameManager.gameOver = true;
        }

        RegenHealth();
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasAWeapon)
            {
                if (currentWeapon == 1)
                {
                    //knife attack
                    //reference knife script & use knife attack function.

                    GameObject.Find("Knife").GetComponent<KnifeScript>().KnifeAttack();
                    
                    
                }

                else if (currentWeapon >= 2)
                {
                    //gun attack
                    //reference gun script & use the shoot function.

                    Weapon_Gun gunScript; gunScript = weapons[2].GetComponent<Weapon_Gun>();
                    gunScript.ShootBullet();

                    

                }
                else
                {
                    return;
                }
            }
            else if (!hasAWeapon)
            {
                return;
            }
        }
    }

    public void SetHealth()
    {
        // the slider changes as the health decreases or increases
        healthSlider.value = health;
        healthText.text = ($"{health}");
    }

    public void SetMaxHealth()
    {
        //max health in slider is equal to max health
        //if max health changes then the sliders max health will also change
        healthSlider.maxValue = maxHealth;
    }

    void WeaponSelection()
    {
        //if you click 1, change to the first weapon, click 2, the second weapon, etc..

        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons[1] != null)
        {
            ChangeWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons[2] != null)
        {
            ChangeWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons[3] != null)
        {
            ChangeWeapon(3);
        }
    }

    void ChangeWeapon(int weapon)
    {
        weapons[currentWeapon].gameObject.SetActive(false);
        currentWeapon = weapon;
        for (int i = 0; i < weapons.Count; i++) {
            if (i == weapon)
            {
                weapons[i].gameObject.SetActive(true);
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            //die
            gameManager.GameOver();
        }
    }

    public void RegenHealth()
    {
        if(health < maxHealth)
        {
            regenCoolDown -= Time.deltaTime;
            if(regenCoolDown == 0)
            {
                health += healthRegen;
                regenCoolDown = 3;
                if(health >= maxHealth)
                {
                    health = maxHealth;
                }
            }
        }
    }

    void CheckForWeapon()
    {
        if (hasAWeapon == true)
        {
            return;
        }
        else
        {
            if (weapons.Count < 1)
            {
                return;
            }

            if (weapons.Count >= 1)
            {
                hasAWeapon = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    { /*
        if (other.CompareTag("KnifePickup"))
        {
            if (GameObject.Find("Knife").gameObject.activeInHierarchy == false)
            {
                GameObject.Find("Knife").gameObject.SetActive(true);
                weapons.Add(GameObject.Find("Knife"));
            }
        } */
    }
}
