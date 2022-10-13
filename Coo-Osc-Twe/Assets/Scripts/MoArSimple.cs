using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoArSimple : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    float periodo = 20; 

    [SerializeField]
    [Range(0, 100)]
    private float amplitud = 40; 

    void Update()
    {
        float factor = Time.time / periodo;
        float x = amplitud * Mathf.Sin(2 * Mathf.PI * factor);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
