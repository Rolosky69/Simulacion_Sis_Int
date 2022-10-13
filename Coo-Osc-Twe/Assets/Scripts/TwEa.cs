using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwEa : MonoBehaviour
{
    
    [SerializeField] Transform objetivo;
    [SerializeField] float tiempo; [SerializeField, Range(0, 1)] float tParametro = 0; 
    [SerializeField] Color colorInicial; [SerializeField] Color colorObjetivo;
    [SerializeField] private AnimationCurve curva;
    
    float cTime;
    Vector3 inPosition;
    Vector3 obPosition;
    Renderer sRenderer;
    
    private void Start()
    {
        sRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        tParametro = cTime / tiempo;
        transform.position = Vector3.LerpUnclamped(inPosition, obPosition, curva.Evaluate(tParametro));
        sRenderer.material.color = Color.LerpUnclamped(colorInicial, colorObjetivo, curva.Evaluate(tParametro));
        cTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }
    private void StartTween()
    {
        tParametro = 0;
        cTime = 0;
        inPosition = transform.position;
        obPosition = objetivo.position;
    }
    private float EaseInElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;
        return x ==0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
