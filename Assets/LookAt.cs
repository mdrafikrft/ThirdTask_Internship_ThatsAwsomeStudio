using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] GameObject lookAtCentre;

    private void Update()
    {
        transform.LookAt(lookAtCentre.transform, Vector3.forward);

    }
}
