using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Bullet tempBullet = null;
    public static Shooter Instance;
    Gun gun;
    void Awake()
    {
        Instance = this;
        gun = new Gun();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        BulletPool.Instance.AllocateBullet(transform.position);
    }
}
