using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private CubesPool<CubeMover> cubeMoverPool;

    [SerializeField]
    private CubeMover cubePrefab;

    private float speed;
    private float distance;
    private float timeToSpawn;
    public bool IsStopped { get; private set; }
    private float timer;

    private void Awake()
    {
        cubeMoverPool = new CubesPool<CubeMover>(cubePrefab, this.transform);
        IsStopped = true;
    }

    private void FixedUpdate()
    {
        if (!IsStopped)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                SpawnCube();
                timer = timeToSpawn;
            }
        }
    }
    public void StartSpawn(float speed, float timeToSpawn, float distance) 
    {
        IsStopped = false;
        SetSetingsValues(speed, timeToSpawn, distance);
        SpawnCube();
    }
    public void StopSpawn()
    {
        IsStopped = true;
        cubeMoverPool.ClearPool();
    }

    private void SetCubeSettings(CubeMover cube, float speed, float distance) 
    {
        cube.Speed = speed;
        cube.Distance = distance;
    }
    private void SetSetingsValues(float speed, float timeToSpawn, float distance) 
    {
        this.speed = speed;
        this.timeToSpawn = timeToSpawn;
        this.distance = distance;
        this.timer = timeToSpawn;
    }
    private void SpawnCube()
    {
        var cube = cubeMoverPool.GetOrCreateFreeElement();
        cube.transform.localPosition = Vector3.zero;
        SetCubeSettings(cube, speed, distance);
    }
}
