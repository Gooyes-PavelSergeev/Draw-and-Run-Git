using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCoin : PickableItem
{
    [SerializeField] private int m_Amount = 1;
    [SerializeField] private float rotateSpeedInDegrees = 50f;
    [SerializeField] private GameObject m_PickupParticles;

    public override void Pickup()
    {
        var wallet = FindObjectOfType<Wallet>();
        var particles = Instantiate(m_PickupParticles, this.transform.parent);
        particles.transform.position = this.transform.position + new Vector3(0, 0.3f, 0);
        if (wallet)
        {
            wallet.CoinAmount += m_Amount;
        }

        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeedInDegrees * Time.deltaTime, 0);
    }
}
