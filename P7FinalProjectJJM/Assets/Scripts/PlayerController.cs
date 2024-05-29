using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 50f;
    public int health = 100;

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

    private void Awake()
    {

    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
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

        if (grounded)
        {
            playerRb.drag = groundDrag;
        }
        else
        {
            playerRb.drag = 0;
            Physics.gravity *= 3;
        }
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    void Inventory()
    {
        
    }
}
