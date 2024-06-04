using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BoxCollider bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {

        if ((collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyComponent)))
        {
            enemyComponent.Damaged();
        }
        Destroy(bullet);

    }
}
