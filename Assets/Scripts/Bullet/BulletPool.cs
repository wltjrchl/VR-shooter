using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    Vector3 enqueuedBulletPosition = new Vector3(100, 100, 100);

    [SerializeField]
    int bulletSize = 100;
    Queue<Bullet> bulletQueue = null;
    
    [SerializeField]
    GameObject bulletObject = null;
    public static BulletPool Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Init();
    }
    void Init()
    {
        bulletQueue = new Queue<Bullet>();
        InitQueue();
    }

    void InitQueue()
    {
        for(int i = 0; i < bulletSize; i++)
        {
            Instance.bulletQueue.Enqueue(GenerateBullet());
        }
        Debug.Log(bulletQueue.Count);
    }

    Bullet GenerateBullet()
    {
        Bullet tempBullet = Instantiate(bulletObject).GetComponent<Bullet>();
        tempBullet.transform.SetParent(this.transform);
        tempBullet.gameObject.SetActive(false);
        tempBullet.transform.position = enqueuedBulletPosition;
        return tempBullet;
    }

    public void AllocateBullet(Vector3 gunPosition)
    {
        if(Instance.bulletQueue.Count != 0)
        {
            Bullet tempBullet = Instance.bulletQueue.Dequeue();
            tempBullet.transform.position = gunPosition;
            tempBullet.gameObject.SetActive(true);
            tempBullet.SetBullet();
            Debug.Log("Bullet Allocated Queue Count = " + bulletQueue.Count);
        }
        else
        {
            Debug.Log("Queue is Empty");
        }
    }

    public void FreeBullet(Bullet freedBullet)
    {
        freedBullet.gameObject.SetActive(false);
        freedBullet.transform.position = enqueuedBulletPosition;
        Instance.bulletQueue.Enqueue(freedBullet);
        Debug.Log("Bullet Freed Queue Count = " + bulletQueue.Count);
    }
}
