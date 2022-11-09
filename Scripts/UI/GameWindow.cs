using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameWindow : MonoBehaviour
{
    [SerializeField] private Button m_StartButton = null;
    [SerializeField] private GameObject m_Content = null;
    [SerializeField] private TextMeshProUGUI m_StatusLabel = null;

    private DrawAndRun m_Game = null;

    private void Awake()
    {
        m_Game = FindObjectOfType<DrawAndRun>();
    }

    private void OnEnable()
    {
        m_Game.OnGameStarted += OnGameStarted;
        m_Game.OnGameFinished += OnGameFinished;
    }

    private void Start()
    {
        m_Content.SetActive(false);
    }

    private void OnGameStarted()
    {
        m_StartButton.gameObject.SetActive(false);
    }

    private void OnGameFinished(bool success)
    {
        m_StatusLabel.text = success ? "Congratulations!" : "You lose!";

        m_Content.SetActive(true);
    }
}
