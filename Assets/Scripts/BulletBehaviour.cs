using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

    public int damage = 20;

    public float explodingRadius = 0f;

    public GameObject bulletImpact;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    public void HitTarget()
    {
        GameObject effectIns = Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if(explodingRadius >= 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodingRadius);
        foreach  (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyBehaviour e = enemy.GetComponent<EnemyBehaviour>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodingRadius);
    }
}
