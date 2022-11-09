using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnGroup : MonoBehaviour
{
    protected Vector3[] GetSpawnPositions()
    {
        var grid = GetComponent<GridPlacement>();

        var collider = GetComponent<BoxCollider>();

        collider.size = grid.TotalSize();

        Vector3[] positions = grid.Calculate();

        return positions;
    }
}
