using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

	public float Interval;
	public float Offset;

	public GameObject ProjectilePrefab;

	private float timer;
    private bool isShooting;

	// Use this for initialization
	void Start () {
		timer = Offset;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0 && isShooting)
		{
			GameObject newProjectile = Instantiate(ProjectilePrefab);

			Projectile projectile = newProjectile.GetComponent<Projectile>();
			
			Destroy(newProjectile, projectile.LifeTime);

			projectile.shooter = gameObject;

			timer = Interval;
		}
	}

    public void SetIsShooting(bool _isShooting) {
        isShooting = _isShooting;
        if (isShooting && timer < 0) timer = Offset;
    }

}
