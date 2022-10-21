using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralWorlds : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int nodes = 5;

    int currentNode = 0;
    Queue<GameObject> newBranches = new Queue<GameObject>();
    Queue<GameObject> frontier = new Queue<GameObject>();

    private void Start()
    {
        GameObject root = Instantiate(prefab, transform);
        root.name = "Arbol";
        frontier.Enqueue(root);
        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float offsetAngle)
    {
        GameObject newBranch = Instantiate(prefab, transform);
        
        newBranch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        Quaternion rotation = prevBranch.transform.rotation;
        newBranch.transform.rotation = rotation * Quaternion.Euler(0f, 0f, offsetAngle);

        return newBranch;
    }
    
    private void GenerateTree()
    {
        if (currentNode >= nodes) return;
        currentNode++;

        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            var rightBranch = CreateBranch(branch, -Random.Range(15f, 40f));
            newBranches.Enqueue(rightBranch);
            var leftBranch = CreateBranch(branch, Random.Range(15f, 40f));
            newBranches.Enqueue(leftBranch);
        }
        
        int branches = newBranches.Count;
        
        for (int i = 0; i < branches; i++)
        {
            frontier.Enqueue(newBranches.Dequeue());
        }
        GenerateTree();

    }
}
