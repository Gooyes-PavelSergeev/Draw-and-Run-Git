using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGroup : SpawnGroup
{
    [SerializeField] private bool m_IsActive = false;

    [SerializeField] private SpikeObject m_SpikePrefab = null;
    [SerializeField] private SpikeObject[] m_Spikes = null;

    public bool IsAcive => m_IsActive;

    private void Start()
    {
        var positions = GetSpawnPositions();
        m_Spikes = new SpikeObject[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            SpikeObject spike = Instantiate(m_SpikePrefab, transform);
            spike.transform.localPosition = positions[i];
            m_Spikes[i] = spike;
        }
        UpdateState();
    }

    private void UpdateState()
    {
        for (int i = 0; i < m_Spikes.Length; i++)
        {
            m_Spikes[i].UpdateState(m_IsActive);
        }
    }

    private void OnValidate()
    {
        UpdateState();
    }
}
