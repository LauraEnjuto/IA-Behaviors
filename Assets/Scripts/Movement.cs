using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);
    }
}

