using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{

    public float damage;
    public GameObject bullet;
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
        Instantiate(bullet);
    }


}
