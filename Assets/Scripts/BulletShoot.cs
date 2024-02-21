using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform BulletPlace;
    [SerializeField] private AudioClip bulletSound;
    [SerializeField] private AudioSource gunAudio;

    GunController gunController;

    InputControl inputControl;

    private void Awake()
    {
        inputControl = new InputControl();
    }

    private void Start()
    {
        gunController = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>();
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
        Instantiate(bullets[RandomIndex], BulletPlace.position, BulletPlace.rotation);
        gunController.StartCoroutine("gunRecoil");
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
