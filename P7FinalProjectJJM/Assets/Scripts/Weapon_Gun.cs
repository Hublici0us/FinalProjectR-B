using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    public Rigidbody bullet;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet()
    {
        Rigidbody bulletRb;
        bulletRb = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as Rigidbody;
        bulletRb.transform.Translate(Vector3.forward * bulletSpeed);
    }


}
