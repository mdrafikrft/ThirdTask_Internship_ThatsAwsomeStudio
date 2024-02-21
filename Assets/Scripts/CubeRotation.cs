using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    private int lifeOfCube = 5;

    private void Update()
    {
        transform.Rotate(0, 10 * rotationSpeed * Time.deltaTime, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            lifeOfCube--;
            Destroy(collision.gameObject);
        }
        if(lifeOfCube <= 0)
        {
            Handheld.Vibrate();
            Destroy(gameObject);
        }
    }
}
