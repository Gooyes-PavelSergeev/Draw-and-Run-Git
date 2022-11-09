using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : SpawnGroup
{
    [SerializeField] private PickableCoin m_CoinPrefab = null;

    private void Start()
    {
        var positions = GetSpawnPositions();
        for (int i = 0; i < positions.Length; i++)
        {
            PickableCoin coin = Instantiate(m_CoinPrefab, transform);
            coin.transform.localPosition = positions[i];
        }
        GetComponent<Collider>().enabled = false;
    }
}
