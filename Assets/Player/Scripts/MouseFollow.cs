//************************************
// MouseFollow.cs
// File that handles the movement of the player
// following the mouse. That's all
//************************************
// Version: 1.0
// Date: 05/06/2025 - PocketSalt
//       Creation
//************************************

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Vector2 m_mousePosition;
    
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector2 m_minBounds;
    [SerializeField] private Vector2 m_maxBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // make cursor invisible
        Cursor.visible = false;
    }

    private void Update()
    {
        m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        m_mousePosition.x = Mathf.Clamp(m_mousePosition.x, m_minBounds.x, m_maxBounds.x);
        m_mousePosition.y = Mathf.Clamp(m_mousePosition.y, m_minBounds.y, m_maxBounds.y);

        // only do if game state is play
        if (GameManager.Instance.currentGameState == GameState.PLAY)
            rb.MovePosition(m_mousePosition);
    }
}
