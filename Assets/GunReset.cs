using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReset : MonoBehaviour
{
    [SerializeField] Vector3 resetPosition;

    public Vector3 gunDefaultPosition;
    public bool canMove = true;

    
    public void BackToDefaultPosition()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, gunDefaultPosition, 0.01f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        canMove = false;
    }
}
