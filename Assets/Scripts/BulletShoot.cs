using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform BulletPlace;
    [SerializeField] private AudioClip bulletSound;
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private float bulletSpeed;

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
        int RandomIndex = Random.Range(0, bullets.Length);
        var bullet = Instantiate(bullets[RandomIndex], BulletPlace.position, BulletPlace.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletPlace.forward * bulletSpeed;

        gunController.BackToDefaultPosition();
        gunAudio.PlayOneShot(bulletSound);
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
