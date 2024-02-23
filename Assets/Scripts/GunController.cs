using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GunController : MonoBehaviour
{
    [SerializeField] Vector3 gunDefaultPosition;
    float zAngle;
    float back;
    bool move = true;
    bool canMove = true;

    
    private void Update()
    {
        if (move && canMove)
        {
            up();
        }

        if (!move && canMove)
        {
            down();
        }
    }

    private void up()
    {
        zAngle += 0.5f;
        zAngle = Mathf.Clamp(zAngle, -40, 70);
        transform.localRotation = Quaternion.Euler(0, -97.6f, zAngle);
        Debug.Log(zAngle);
        if(zAngle == 70)
        {
            back = 70;
            move = !move;
        }
        
    }

    private void down()
    {
        back -= 0.5f;
        back = Mathf.Clamp(back, -40, 70);
        transform.localRotation = Quaternion.Euler(0, -97.6f, back);
        if(back == -40)
        {
            zAngle = -40;
            move = !move;
        }

    }

    public void BackToDefaultPosition()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, gunDefaultPosition, 0.01f);
        transform.localRotation = Quaternion.Euler(0, -97.6f, 0);
        canMove = false;
    }

    
}
