using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Transform axis, plane;
    [SerializeField] private float rotateSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        axis.Rotate(Vector3.up * Time.deltaTime * Random.Range(0.9f, 1.1f) * rotateSpeed);
    }
}
