using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridArray : MonoBehaviour
{
    public List<Transform> gridTransforms;
    public bool[] gridTaken;
    int chosenGrid;

    private void Start()
    {
        gridTransforms.AddRange(GetComponentsInChildren<Transform>());
        gridTransforms.RemoveAt(0);
        gridTaken = new bool[gridTransforms.Count-1];
    }

    public Transform GetUnoccupiedLocation()
    {
        List<int> availableGrids = new List<int>();

        for(int i = 0; i < gridTransforms.Count - 1; i++)
        {
            if (!gridTaken[i])
            {
                availableGrids.Add(i);
            }
        }

        if(availableGrids.Count == 0)
        {
            print("Grid filled");
            return null;
        }

        chosenGrid = availableGrids[Random.Range(0, availableGrids.Count - 1)];

        Transform newTransform = gridTransforms[chosenGrid];

        gridTaken[chosenGrid] = true;

        return newTransform;
    }

    public int GetIndexOfLocation(int i)
    {
        return chosenGrid;
    }
}
