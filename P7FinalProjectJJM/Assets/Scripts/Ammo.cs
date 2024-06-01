using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // tried to make ammo, doesnt work, delete script later
    public BoxCollider ammoCollider;
    private int ammoCount = 10;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        ammoCollider = GetComponent<BoxCollider>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerController.hasGun == true)
        {

        }
    }
}
