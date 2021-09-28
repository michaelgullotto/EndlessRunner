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
        // choose random spot to spawn obstacles 
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
            // moves spawner to selected location
            spawner.transform.position = targetpos;
            //spawns
            Instantiate(obstacle, transform.position, quaternion.identity);
            //resets spawn timer
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            // counts down to next spawn
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
