using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLookAtMovimientosss : MonoBehaviour
{
    [SerializeField]
    float rapidez = 10;
    Vector2 velocidad;
    Vector2 aceleracion;
    
    void Update()
    {
        Vector2 worldMousePosition = GetWorldMousePosition();
        Vector2 thisPosition = transform.position;

        aceleracion = worldMousePosition - thisPosition;
        
        velocidad += aceleracion * Time.deltaTime;
        
        LookAt(thisPosition + velocidad);

        Vector3 finalPosition = new Vector3(velocidad.x, velocidad.y, 0);
        transform.position += finalPosition * Time.deltaTime;
    }

    private void LookAt(Vector2 targetPosition)
    {
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = targetPosition - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / 2;
        RotateZ(radians);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}