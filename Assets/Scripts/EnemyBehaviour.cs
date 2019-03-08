﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed = 5f;
    public float healthPoints = 100f;
    public GameObject deathFX;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        if(healthPoints <= 0f)
        {
            GameObject enemyDeathFX = Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(enemyDeathFX, 2f);

            Destroy(gameObject);
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;

        target = Waypoints.points[wavePointIndex];
    }
}
