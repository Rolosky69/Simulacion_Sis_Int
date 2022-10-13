using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    [Header("Transformacion Cuadricula")]

    [SerializeField] Vector3 posicion; [SerializeField] Vector3 rotacion; [SerializeField] Vector3 escala;

    [Header("Cuadricula")]
    
    [SerializeField]
    float tamanoCuadros = 0.15f;
    [SerializeField]
    int totalCuadros = 50;
    [SerializeField]
    bool ejeX = true; [SerializeField] bool ejeZ = true; [SerializeField] bool ejeY = true;
    [SerializeField]
    Transform bolita;

    Matrix4x4 matrix;
    Vector3 otherObjectInitialPosition;


    private void Start()
    {
        otherObjectInitialPosition = bolita.position;
    }

    private void Update()
    {
        matrix = Matrix4x4.TRS(posicion, Quaternion.Euler(rotacion), escala);
        UpateOtherObject();
        DrawBasis();
        DrawPlanes();
    }

    private void UpateOtherObject()
    {
        if (bolita == null) return;
        
        bolita.position = otherObjectInitialPosition;
        bolita.position = matrix.MultiplyPoint3x4(bolita.position);
    }

    private void DrawBasis()
    {
        Vector3 pos = matrix.GetColumn(3);
        Debug.DrawRay(pos, matrix.GetColumn(0), Color.black);
        
        Debug.DrawRay(pos, matrix.GetColumn(1), Color.red);
        
        Debug.DrawRay(pos, matrix.GetColumn(2), Color.white);
    }

    private void DrawPlanes()
    {
        Vector3 pos = matrix.GetColumn(3);
        
        Vector3 xAxis = matrix.GetColumn(0);
        
        Vector3 yAxis = matrix.GetColumn(1);
        
        Vector3 zAxis = matrix.GetColumn(2);
        
        if (ejeX) DrawGrid(pos, xAxis, yAxis, escala.x, escala.y);
        
        if (ejeZ) DrawGrid(pos, zAxis, xAxis, escala.z, escala.x);
        
        if (ejeY) DrawGrid(pos, yAxis, zAxis, escala.y, escala.z);
    }

    private void DrawGrid(Vector3 pos, Vector3 xAxis, Vector3 yAxis, float scaleX, float scaleY)
    {
        for (int i = 1; i <= totalCuadros; ++i)
        {
            Debug.DrawRay(pos + xAxis * tamanoCuadros * i, yAxis.normalized * tamanoCuadros * totalCuadros * Mathf.Abs(scaleY));
            
            Debug.DrawRay(pos + yAxis * tamanoCuadros * i, xAxis.normalized * tamanoCuadros * totalCuadros * Mathf.Abs(scaleX));
        }
    }
}
