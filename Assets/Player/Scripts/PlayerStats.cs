using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int HP;

    private void Update()
    {
        if (GameManager.Instance.currentGameState == GameState.PLAY)
        {
            if (HP <= 0)
                GameManager.Instance.currentGameState = GameState.DEAD;
        }
    }
}
