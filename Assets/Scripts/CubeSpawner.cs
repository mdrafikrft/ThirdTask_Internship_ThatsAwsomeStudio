using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    GameObject Cubes;
    [SerializeField] bool canSpawn = true;

    [SerializeField] GameObject cube;

    private void Start()
    {
        Cubes = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        if(Cubes == null && canSpawn)
        {
            Instantiate(cube, transform.position, Quaternion.identity);
            canSpawn = !canSpawn;
            StartCoroutine(cubeSpawn());
        }
        
    }

    IEnumerator cubeSpawn()
    {
        yield return new WaitForSeconds(3.0f);
        canSpawn = true;
    }
}
