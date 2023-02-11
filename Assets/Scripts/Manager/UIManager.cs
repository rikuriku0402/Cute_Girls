using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas BattleCanvas => _battleCanvas;

    [SerializeField]
    [Header("�o�g���L�����o�X")]
    private Canvas _battleCanvas;

    [SerializeField]
    [Header("�L�����I���L�����o�X")]
    private Canvas _charaCanvas;


    private void Start()
    {
        _battleCanvas.gameObject.SetActive(false);
        _charaCanvas.gameObject.SetActive(true);
    }
}
