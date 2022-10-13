using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGraph : MonoBehaviour
{
    [SerializeField] private GameObject m_pointPrefab;
    [SerializeField] int m_totalSamplePoints = 25;
    [SerializeField] float largo = 0.6f; [SerializeField] float anchura = 0.5f;

    private List<GameObject> newPoints = new List<GameObject>();

    private void Start()
    {
        for(int i=0; i < m_totalSamplePoints; i++)
        {
            var newPoint = Instantiate(m_pointPrefab, transform);
            
            newPoints.Add(newPoint);
            
        }
    }
    private void Update()
    {
        for(int i =0; i<m_totalSamplePoints; i++)
        {
            var newPoint = newPoints[i];
            
            float x = i * anchura;
            float y = largo * Mathf.Sin(i + Time.time);
            
            newPoint.transform.localPosition = new Vector3(x, y);
        }
    }
}
