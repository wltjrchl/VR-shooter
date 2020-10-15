using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    int hp = 60;

    public void ReceiveDamage(int damage)
    {
        hp -= damage;
        
        if(damage <= 0)
        {
            //TargetPool.FreeTarget(this.gameObject)
           // Destroy(this.gameObject);
        }
    }
}
