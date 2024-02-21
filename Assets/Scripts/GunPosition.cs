using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : MonoBehaviour
{
    [SerializeField] private Transform cameraPostion;


    private void Update()
    {
        transform.position = cameraPostion.position;
    }
}
