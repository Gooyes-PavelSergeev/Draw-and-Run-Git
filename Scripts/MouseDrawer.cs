﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseDrawer : MonoBehaviour
{
    public event Action OnPointsGenerated = null;

    [SerializeField] private RectTransform m_RectTransform = null;
    [SerializeField] private float m_DistanceThreshold = 10;

    private bool m_IsDrawing = false;

    private List<Vector2> m_Points = new List<Vector2>();

    public List<Vector2> Points => m_Points;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_Points.Clear();

            m_IsDrawing = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            m_IsDrawing = false;

            if (m_Points.Count >= 2)
            {
                OnPointsGenerated?.Invoke();
            }
        }

        if (m_IsDrawing)
        {
            HandleDrawing(Input.mousePosition);
        }
    }


    private Vector2 GetPosition01(Vector3 screenPosition)
    {
        Vector3[] corners = new Vector3[4];
        m_RectTransform.GetWorldCorners(corners);

        Vector2 horizontal = new Vector2(corners[0].x, corners[3].x);
        Vector2 vertical = new Vector2(corners[0].y, corners[1].y);

        Vector2 position01 = new Vector2(
            Mathf.InverseLerp(horizontal.x, horizontal.y, screenPosition.x),
            Mathf.InverseLerp(vertical.x, vertical.y, screenPosition.y)
        );

        return position01;
    }

    private void HandleDrawing(Vector3 screenPosition)
    {
        bool inInside = RectTransformUtility.RectangleContainsScreenPoint(m_RectTransform, screenPosition);

        if (!inInside)
        {
            return;
        }

        Vector3 pos = GetPosition01(screenPosition);

        if (m_Points.Count == 0)
        {
            m_Points.Add(pos);
        }
        else
        {
            Vector3 last = m_Points[m_Points.Count - 1];
            if (Vector3.Distance(pos, last) > m_DistanceThreshold * 0.01f)
            {
                m_Points.Add(pos);
            }
        }
    }
}
