using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{
    Vector3 enqueuedTargetPosition = new Vector3(100, 100, 100);

    [SerializeField]
    int targetSize = 100;
    Queue<Target> targetQueue;
    
    [SerializeField]
    GameObject targetObject = null;
    public static TargetPool Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Init();
    }
    void Init()
    {
        targetQueue = new Queue<Target>();
        InitQueue();
    }

    public void InitQueue()
    {
        for(int i = 0; i < targetSize; i++)
        {
             targetQueue.Enqueue(GenerateTarget());
        }
        Debug.Log(targetQueue.Count);
    }

    Target GenerateTarget()
    {
        Target tempTarget = Instantiate(targetObject).GetComponent<Target>();
        tempTarget.transform.SetParent(this.transform);
        tempTarget.gameObject.SetActive(false);
        tempTarget.transform.position = enqueuedTargetPosition;
        return tempTarget;
    }
}
