using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    [Header("クリアキャンバス")]
    private Canvas _clearCanvas;

    public void GoalClear()
    {
        print("ゴール");
        _clearCanvas.gameObject.SetActive(true);
    }
}
