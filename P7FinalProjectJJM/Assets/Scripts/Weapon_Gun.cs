using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{
    public float bulletSpeed = 25;
    public float fireRate;
    public int damage;

    //public GameObject weaponHolder; trying to make a weapon holder so you can switch weapons. 
    public Rigidbody bullet;
    public GameObject gun;
    public BoxCollider bulletCollider;

    private PlayerController playerController;
 
    // Start is called before the first frame update
    void Start()
    {
        bulletCollider = GameObject.Find("Bullet").GetComponent<BoxCollider>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet()
    {
        Rigidbody bulletRb;
        bulletRb = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as Rigidbody;
        bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            damage += playerController.damageMod;
            enemyController.enemyHealth -= damage;
            Destroy(bullet);
        }
    }*/


}
