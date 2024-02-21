using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GunController : MonoBehaviour
{
    Animator gun;

    private void Start()
    {
        gun = GetComponent<Animator>();
    }
    
    public IEnumerator gunRecoil()
    {
        gun.Play("GunRecoil");
        yield return new WaitForSeconds(0.3f);
        gun.Play("New State");
    }
}
