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

    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;

    bool grounded;

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

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
