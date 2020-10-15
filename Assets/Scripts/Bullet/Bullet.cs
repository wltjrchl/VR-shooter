using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float velocity = 2;
    [SerializeField]
    int damage = 60;
    [SerializeField]
    float bulletLifeTimeLimit = 5.0f;
    float bulletLifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        TimeLimit();
    }

    void TimeLimit()
    {
        if(bulletLifeTime < bulletLifeTimeLimit)
        {
            bulletLifeTime += Time.deltaTime;
        }
        else
        {
            BulletPool.Instance.FreeBullet(this);
        }
    }
    public void SetBullet()
    {
        this.bulletLifeTime = 0;
    }

    void DealDamageToTarget(GameObject target)
    {
        target.GetComponent<Target>().ReceiveDamage(damage);
    }

    void Move()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            DealDamageToTarget(other.gameObject);
            Debug.Log("Target");
        }
        else
        {
            Debug.Log("NotTarget");
        }
        BulletPool.Instance.FreeBullet(this);
    }
}
