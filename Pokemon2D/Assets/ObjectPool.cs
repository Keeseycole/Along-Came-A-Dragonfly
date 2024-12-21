using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> pool= new List<T>();

    private readonly T prefab;

    private readonly Transform parent;

    public ObjectPool(T prefab, Transform parentRef)
    {
       this.parent = parentRef;
        this.prefab = prefab;
    }

    public T GetObject()
    {
        foreach (var item in pool)
        {
            if(item.gameObject.activeInHierarchy == false)
            {
                item.gameObject.SetActive(true);

                return item;
            }

        }
        T newObject = GameObject.Instantiate(prefab, parent);
        pool.Add(newObject);
        return newObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        if (pool.Contains(obj) == false)
        {
            pool.Add(obj);
        }
    }
}

