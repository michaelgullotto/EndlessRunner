using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    [SerializeField] private int roll;
    private Vector2 targetpos;
    [SerializeField] private GameObject spawner;

    private void Start()
    {
        targetpos = spawner.transform.position;
    }

    void Update()
    {
        
        if (timeBtwSpawn <= 0)
        {
            roll = Random.Range(1,4);
            if (roll == 1)
            {
                targetpos.x = 2f;
            }
            else if (roll == 2)
            {
                targetpos.x = 0f;
            }
            else if (roll == 3)
            {
                targetpos.x = -2f;
            }

            spawner.transform.position = targetpos;
            Instantiate(obstacle, transform.position, quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
