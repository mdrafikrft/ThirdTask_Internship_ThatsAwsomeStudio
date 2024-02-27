using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform BulletPlace;
    [SerializeField] private AudioClip bulletSound;
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject Gun;

    GunController gunController;
    Vector3 defaultGunPosition; 

    InputControl inputControl;

    private void Start()
    {
        gunController = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>();
        defaultGunPosition = gunController.gunDefaultPosition;
    }

    private void Awake()
    {
        inputControl = new InputControl();
    }

    
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (inputControl.Player.Shoot.triggered)
        {
            GunController.canReset = false;
            ShootBullet();
        }
    }
    public void ShootBullet()
    {
        //Gun Recoil
        StartCoroutine(GunRecoil());

        int RandomIndex = Random.Range(0, bullets.Length);
        var bullet = Instantiate(bullets[RandomIndex], BulletPlace.position, BulletPlace.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletPlace.forward * bulletSpeed;

        gunAudio.PlayOneShot(bulletSound);

        gunController.BackToDefaultPosition();
        GunController.resetTime = 2;
    }

    IEnumerator GunRecoil()
    {
        float z = Gun.transform.position.z - 0.20f;/*
        Debug.Log("Z = " + z);*/
        z = Mathf.Clamp(z, 0.321f, 0.521f);
        Vector3 targetPos = new Vector3(defaultGunPosition.x, defaultGunPosition.y, z);
        Gun.transform.localPosition = Vector3.Slerp(defaultGunPosition, targetPos, 0.2f);

        yield return new WaitForSeconds(0.1f);

        z += 0.20f;
        z = Mathf.Clamp(z, 0.521f, 0.621f);
        Gun.transform.localPosition = new Vector3(defaultGunPosition.x, defaultGunPosition.y, z);
        //Gun.transform.position = Vector3.Slerp(Gun.transform.position, originalPosition, 0.1f);
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }



}
