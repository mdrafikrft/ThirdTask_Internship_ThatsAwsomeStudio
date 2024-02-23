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

    InputControl inputControl;

    private void Start()
    {
        gunController = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>();
    }

    private void Awake()
    {
        inputControl = new InputControl();
    }

    
    private void Update()
    {
        if (inputControl.Player.Shoot.triggered)
        {
            ShootBullet();
        }  
    }
    public void ShootBullet()
    {
        //Gun Recoil
        StartCoroutine("GunRecoil");

        int RandomIndex = Random.Range(0, bullets.Length);
        var bullet = Instantiate(bullets[RandomIndex], BulletPlace.position, BulletPlace.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletPlace.forward * bulletSpeed;

        gunController.BackToDefaultPosition();
        gunAudio.PlayOneShot(bulletSound);
    }

    IEnumerator GunRecoil()
    {
        float z = Gun.transform.position.z - 0.20f;
        Debug.Log("Z = " + z);
        Vector3 targetPos = new Vector3(Gun.transform.position.x, Gun.transform.position.y, z);
        Gun.transform.position = Vector3.Slerp(Gun.transform.position, targetPos, 0.2f);

        yield return new WaitForSeconds(0.1f);

        z += 0.20f;
        Gun.transform.position = new Vector3(Gun.transform.position.x, Gun.transform.position.y, z);
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
