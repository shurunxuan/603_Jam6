using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public GameObject shooter;

	public float LifeTime;

	public int Damage;

    public GameObject explodeEffectPrefab;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == null) return;
		if (shooter == null) return;

		if (col.gameObject != shooter.transform.root.GetComponent<InputController>().shipController.gameObject)
		{
			col.gameObject.SendMessage("DamageDealed", Damage);

            //EXPLODE!
            Instantiate(explodeEffectPrefab, col.transform.position, Quaternion.identity);

			Destroy(gameObject);
		}
	}
}
