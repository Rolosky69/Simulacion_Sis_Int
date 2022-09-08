using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallBall : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    private MyVector posicion;
    private MyVector desplazamiento;
    [SerializeField] private MyVector velocidad; 
    [SerializeField] private MyVector acceleracion;
    MyVector[] accelerations =
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0f),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0f),
    };
    private void Start()
    {
        posicion = transform.position; 
    }
    public void Move()
    {
        velocidad += acceleracion * Time.fixedDeltaTime;
        posicion += velocidad * Time.fixedDeltaTime;
        transform.position = posicion;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        posicion.Draw(Color.green);
        desplazamiento.Draw2(posicion, Color.blue);
        velocidad.Draw2(posicion, Color.red);
        acceleracion = objetivo.position - transform.position;
    }
}
