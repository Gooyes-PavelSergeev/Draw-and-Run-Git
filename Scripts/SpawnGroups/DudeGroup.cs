using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeGroup : SpawnGroup
{
    [SerializeField] private PickableDude m_DudePrefab = null;

    private void Start()
    {
        var positions = GetSpawnPositions();
        for (int i = 0; i < positions.Length; i++)
        {
            PickableDude dude = Instantiate(m_DudePrefab, transform);
            dude.transform.localPosition = positions[i];
        }
        GetComponent<Collider>().enabled = false;
    }
}
