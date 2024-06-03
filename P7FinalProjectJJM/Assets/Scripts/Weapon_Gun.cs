using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{
    public float bulletSpeed = 100;
    public float fireRate;

    //public GameObject weaponHolder; trying to make a weapon holder so you can switch weapons. 
    public GameObject bullet;
    public Transform crossHairs;
    public BoxCollider bulletCollider;

    private PlayerController playerController;
 
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet()
    {
        GameObject bangBullet = Instantiate(bullet);
        bangBullet.transform.position = crossHairs.position;
        bangBullet.transform.rotation = bullet.transform.rotation;

        bangBullet.GetComponent<Rigidbody>().AddForce(crossHairs.forward * bulletSpeed, ForceMode.Impulse);
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
