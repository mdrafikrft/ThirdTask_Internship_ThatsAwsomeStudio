using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsBehaviour : MonoBehaviour
{
    Rigidbody bulletRigidBody;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLife;
    //[SerializeField] private Transform bulletSpawnPlace;


    private void Start()
    {/*
        bulletRigidBody = GetComponent<Rigidbody>();

        bulletRigidBody.velocity = bulletSpawnPlace.forward * bulletSpeed;*/
        Destroy(gameObject, bulletLife);
    }
}
