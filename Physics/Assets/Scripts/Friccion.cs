using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friccion : MonoBehaviour
{
    private MyVector posicion;
    private MyVector velocidad;
    private MyVector aceleracion;
    [SerializeField] bool friccion = false;
    [SerializeField] float masa = 1;
    [SerializeField] MyVector viento;
    [SerializeField][Range(0, 1)] float friccionCoeficiente;
    [SerializeField][Range(0, 1)] float damping = 1;
    [SerializeField][Range(0, 1)] float gravedad = -9.8f;

    private void Start()
    {
        posicion = transform.position;
    }
    public void Move()
    {
        velocidad += aceleracion * Time.fixedDeltaTime;
        posicion += velocidad * Time.fixedDeltaTime;
        if (Mathf.Abs(posicion.x) >= 5)
        {
            posicion.x = Mathf.Sign(posicion.x) * 5;
            velocidad.x *= -1;
            velocidad *= damping;
        }
        if (Mathf.Abs(posicion.y) >= 5)
        {
            posicion.y = Mathf.Sign(posicion.y) * 5;
            velocidad.y *= -1;
            velocidad *= damping;
        }
        transform.position = posicion;
    }
    private void FixedUpdate()
    {
        float weightScalar = masa * gravedad;
        MyVector weight = new MyVector(0, weightScalar);
        MyVector friction = velocidad.normalized * friccionCoeficiente * -weightScalar * -1;
        aceleracion *= 0f;
        ApplyForce(viento);
        ApplyForce(weight);
        ApplyForce(friction);
        if (friccion && posicion.y <= 0f)
        {
            float velocityMagnitude = velocidad.magnitude;
            float frontalArea = transform.localScale.x;
            MyVector fluidFriction = velocidad.normalized * frontalArea * velocityMagnitude * velocityMagnitude * -0.5f;
            ApplyForce(fluidFriction);
            fluidFriction.Draw2(posicion, Color.red);
        }
        friction.Draw2(posicion, Color.green);
        Move();
    }
    private void Update()
    {
        velocidad.Draw2(posicion, Color.blue);
    } 
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / masa);
    }
}