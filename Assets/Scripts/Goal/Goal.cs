using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    [Header("クリアキャンバス")]
    private Canvas _clearCanvas;

    private void Start()
    {
        _clearCanvas.gameObject.SetActive(false);
    }

    public void GoalClear()
    {
        print("ゴール");
        _clearCanvas.gameObject.SetActive(true);
    }
}
