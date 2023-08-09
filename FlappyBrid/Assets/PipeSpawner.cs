using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform pipePrefab;

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            Instantiate(pipePrefab, transform.position + new Vector3(0,Random.Range(-0.21f, 0.58f),0), Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }
    }
}