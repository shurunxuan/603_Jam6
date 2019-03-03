using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : Projectile
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = shooter.transform.up;
        transform.position = shooter.transform.position;
        transform.rotation = shooter.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }
}
