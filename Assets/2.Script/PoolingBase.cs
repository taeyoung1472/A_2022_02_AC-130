using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBase : MonoBehaviour
{
    [Header("Ç®¸µ")]
    [SerializeField] protected PoolObject poolIndex;
    [SerializeField] protected PoolManager PoolManager;
    [SerializeField] protected bool isTimePool = false;
    [SerializeField] protected float poolTime;
    public virtual void Start()
    {
        
    }
    public void OnEnable()
    {
        if (!PoolManager) { PoolManager = GameManager.Instance.PoolManager; }
        transform.SetParent(PoolManager.Holder);
        if (isTimePool)
        {
            StartCoroutine(Pool());
        }
    }
    IEnumerator Pool()
    {
        yield return new WaitForSeconds(poolTime);
        transform.SetParent(PoolManager.Get(poolIndex));
        gameObject.SetActive(false);
    }
    public void InstanceaPool()
    {
        transform.SetParent(PoolManager.Get(poolIndex));
        gameObject.SetActive(false);
    }
}
