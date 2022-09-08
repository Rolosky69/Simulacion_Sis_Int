using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class Atraccion : MonoBehaviour
{
    private MyVector posicion;
    private MyVector aceleracion;
    
    [SerializeField] float GMasa = 1;
    [SerializeField] float Masa = 1;
    [SerializeField] private MyVector velocidad;
    [SerializeField][Range(0, 1)]float gravedad = -9.8f;
    [SerializeField] Transform Objetivo;

    private void Start()
    {
        posicion = transform.position;
    }
    public void Move()
    {
        posicion += velocidad * Time.fixedDeltaTime;
        velocidad += aceleracion * Time.fixedDeltaTime;
        
        transform.position = posicion;

    }
    private void FixedUpdate()
    {
        MyVector r = Objetivo.position - transform.position;
        float weightScalar = Masa * gravedad;
        MyVector weight = new MyVector(0, weightScalar);
        aceleracion *= 0f;
        float Magnituder = r.magnitude;
        MyVector F = r.normalized * (1 / GMasa * Masa / Magnituder * Magnituder);

        ApplyForce(F);
        Move();
        F.Draw2(posicion, Color.red);
    }
    private void Update()
    {
        velocidad.Draw2(posicion, Color.green);
    }
   
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / Masa);
    }
}