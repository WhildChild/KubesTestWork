using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPool<T> where T : MonoBehaviour
{
    private T prefab;
    private List<T> pool;

    public Transform container;

    public CubesPool(T prefab, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        CreatePool();
    }

    private void CreatePool()
    {
        pool = new List<T>();
    }

    private T CreateObject(bool isActiveByDefault) 
    {
        var createdObject = Object.Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    public T GetOrCreateFreeElement()
    {
        foreach (var cube in pool) 
        {
            if (!cube.gameObject.activeInHierarchy)
            {
                cube.gameObject.SetActive(true);
                return cube;
            }
        }

        return CreateObject(true);
    }

    public void ClearPool()
    {
        foreach (T cube in pool)
        {
            GameObject.Destroy(cube.gameObject);
        }
        pool.Clear();
    }
}
