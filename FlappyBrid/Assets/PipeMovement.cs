using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Start()
    {
    }

    void Update()
    {
        transform.position -= new Vector3(1, 0) * (speed * Time.deltaTime);
    }
}