using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GunController : MonoBehaviour
{
    public Vector3 gunDefaultPosition;

    float zAngle;
    float back;
    bool move = true;
    bool canMove = true;

    public static int resetTime;
    public static bool canReset;

    
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
        transform.localRotation = Quaternion.Euler(0, -97.6f, zAngle);/*
        Debug.Log(zAngle);*/
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
        transform.localPosition = gunDefaultPosition;
        transform.localRotation = Quaternion.Euler(0, -92.0f, 3.80f);
              
        canMove = false;

        //StartCoroutine(ResetMove());
        if (canReset)
        {
            Invoke("ResetMove", resetTime);
        }
    }

    public void ResetMove()
    {
        //yield return new WaitForSeconds(4.0f);
        canMove = true;
    }
}
