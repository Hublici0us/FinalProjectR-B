using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firstPersonCamera;
    private float speed = 10f;
    public int health = 100;

    private void Awake()
    {
        firstPersonCamera = GetComponent<Transform>();
    }

    private void Start()
    {
        Camera.main.transform.position = firstPersonCamera.transform.position;
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = (Vector3.forward * vertical * speed * Time.deltaTime);
        transform.position = (Vector3.right * horizontal * speed * Time.deltaTime);

    }

    void Update()
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
