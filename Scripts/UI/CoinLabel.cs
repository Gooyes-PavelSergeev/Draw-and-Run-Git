using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Label = null;

    private Wallet m_Wallet = null;

    private void Awake()
    {
        m_Wallet = FindObjectOfType<Wallet>();
    }

    private void OnEnable()
    {
        m_Wallet.OnCoinAmountChanged += OnCoinAmountChanged;
    }

    private void OnDisable()
    {
        m_Wallet.OnCoinAmountChanged -= OnCoinAmountChanged;
    }

    private void OnCoinAmountChanged()
    {
        m_Label.text = $"{m_Wallet.CoinAmount}";
    }
}
