using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 50f;
    public int health = 100;
    public int maxHealth = 100;
    public UnityEngine.UI.Slider healthSlider;
    public TextMeshProUGUI healthText;
    Vector3 MovementDirection;

    public Transform orientation;
    Rigidbody playerRb;

    [Header("Ground Check")]

    public float groundDrag = 5;
    public float playerHeight;
    public LayerMask whatIsGround;

    bool grounded;


    [Header("Weapons")]
    GameObject[] weapons;

    private GameManager gameManager;

    private void Awake()
    {

    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    }

    void Update()
    {
        // ground checking: sends a raycast (invisible arrow tracker thingy) straight down from player position, if detects layer "whatIsGround" then applies drag.
        grounded = Physics.Raycast(gameObject.transform.position, Vector3.down, playerHeight + 0.2f, whatIsGround);

        if (!grounded)
        {
            speed /= 2;
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
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public void SetHealth()
    {
        healthSlider.value = health;
        healthText.text ="" + health;
    }

    public void SetMaxHealth()
    {
        healthSlider.maxValue = maxHealth;
    }
    void Inventory()
    {
        
    }
}
