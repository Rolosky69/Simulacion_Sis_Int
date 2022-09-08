using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class Viento : MonoBehaviour
{
    [SerializeField] float masa = 1;
    [SerializeField] MyVector viento;
    [SerializeField] MyVector gravedad;
    [SerializeField][Range(0, 1)] float damping = 1;
    private MyVector posicion;
    private MyVector velocidad; 
    private MyVector aceleracion;
    
    private void Start()
    {
        posicion = transform.position;
    }
    public void Move()
    {
        velocidad += aceleracion * Time.fixedDeltaTime;
        posicion += velocidad * Time.fixedDeltaTime;     
        if (Mathf.Abs(posicion.y) >= 5)
        {
            posicion.y = Mathf.Sign(posicion.y) * 5;
            velocidad.y *= -1;
            velocidad *= damping;
        }

        transform.position = posicion;
        if (Mathf.Abs(posicion.x) >= 5)
        {
            posicion.x = Mathf.Sign(posicion.x) * 5;
            velocidad.x *= -1;
            velocidad *= damping;
        }
    }
    private void FixedUpdate()
    {
        aceleracion *= 0f;
        ApplyForce(viento);
        ApplyForce(gravedad);
        Move();
    }
    private void Update()
    {
        posicion.Draw(Color.green);
        velocidad.Draw2(posicion, Color.blue);
        aceleracion.Draw2(posicion, Color.red);
    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / masa);
    }
}