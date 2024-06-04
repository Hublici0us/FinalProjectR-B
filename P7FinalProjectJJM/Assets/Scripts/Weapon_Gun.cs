using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{
    public float bulletSpeed = 1000;
    private float fireRate = 0;

    //public GameObject weaponHolder; trying to make a weapon holder so you can switch weapons. 
    public GameObject bullet;
    public Transform crossHairs;
    private PlayerController playerController;
 
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        fireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
    }

    public void ShootBullet()
    { 
        if (fireRate <=0)
        {
            GameObject bangBullet = Instantiate(bullet);
            bangBullet.transform.position = crossHairs.position;

            bangBullet.GetComponent<Rigidbody>().AddForce(crossHairs.forward * bulletSpeed);

            fireRate = 1;
            Destroy(bangBullet, 5);
        }
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
