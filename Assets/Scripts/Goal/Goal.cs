using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    [Header("�N���A�L�����o�X")]
    private Canvas _clearCanvas;

    public void GoalClear()
    {
        print("�S�[��");
        _clearCanvas.gameObject.SetActive(true);
    }
}
