using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile {

    [SerializeField]
    private float thrustStrength;

    [SerializeField]
    private float initialSpeed;

    [SerializeField]
    private float trackingRange = Mathf.Infinity;

    [SerializeField]
    private float maxSpeed = Mathf.Infinity;

    new private Rigidbody2D rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        transform.position = shooter.transform.position;
        transform.rotation = shooter.transform.rotation;
        rigidbody.velocity = transform.up * initialSpeed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 closestTarget = Vector3.positiveInfinity;
        float closestTargetDistance = Mathf.Infinity;
        bool closestTargetSet = false;
        foreach (InputController player in GameManager.instance.GetAllPlayers()) {

            // Skip our shooter
            if (player == shooter.transform.root.GetComponent<InputController>()) continue;

            if (player.shipController == null) continue;
            if (!player.shipController.gameObject.activeSelf) continue;

            Vector2 potentialTargetPos = player.shipController.transform.position;
            Vector2 currentPos = this.transform.position;
            float distance = Vector2.Distance(potentialTargetPos, currentPos);
            if (distance < closestTargetDistance && distance < trackingRange) {
                closestTarget = potentialTargetPos;
                closestTargetDistance = distance;
                closestTargetSet = true;
            }

        }

        Vector2 forceDirection = this.transform.up;
        if (closestTargetSet) {
            forceDirection = (closestTarget - this.transform.position).normalized;
        }
        rigidbody.AddForce(forceDirection * thrustStrength * Time.fixedDeltaTime);

        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        this.transform.up = rigidbody.velocity.normalized;

    }
}
