using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed = 5f;
    public float healthPoints = 100f;
    public int income = 50;
    public GameObject deathFX;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        healthPoints -= amount;

        if(healthPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += income;

        GameObject effect = Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(effect, 2f);
        
        Destroy(gameObject);
    }

    void Update()
    {
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

    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
