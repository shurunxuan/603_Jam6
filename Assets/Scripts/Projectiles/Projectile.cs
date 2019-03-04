using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public GameObject shooter;

	public float LifeTime;

	public int Damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject != shooter.transform.root.GetComponent<InputController>().shipController.gameObject)
		{
			col.gameObject.SendMessage("DamageDealed", Damage);
			Destroy(gameObject);
		}
	}
}
