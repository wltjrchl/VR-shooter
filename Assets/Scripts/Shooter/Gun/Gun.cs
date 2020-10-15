using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    int magazineSize = 6;
    int currentMagazine = 6;
    float fireDelay = 0.5f;
    float reloadDelay = 3.0f;
    void Update()
    {
        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }
        else if(Input.GetMouseButtonDown(0))
        {

        }   
    }
    void Fire()
    {
        BulletPool.Instance.AllocateBullet(transform.position);
    }

    void Reload()
    {
        
    }
}
