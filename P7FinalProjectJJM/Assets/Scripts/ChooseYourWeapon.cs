using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseYourWeapon : MonoBehaviour
{
    public int pickWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PickYourWeapon();
        changeWeapon();
    }

    public void PickYourWeapon()
    {
        int chosen = 0;
        foreach(Transform weapon in transform)
        {
            if(chosen == pickWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            chosen++;
        }
    }

    public void changeWeapon()
    {
        int oldWeapon = pickWeapon;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(pickWeapon >= transform.childCount - 1)
            {
                pickWeapon = 0;
            }
            else
            {
                pickWeapon++;
            }
        }

        if(oldWeapon != pickWeapon)
        {
            PickYourWeapon();
        }
    }
}
