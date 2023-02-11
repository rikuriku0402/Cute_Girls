using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas BattleCanvas => _battleCanvas;

    [SerializeField]
    [Header("バトルキャンバス")]
    private Canvas _battleCanvas;

    [SerializeField]
    [Header("キャラ選択キャンバス")]
    private Canvas _charaCanvas;


    private void Start()
    {
        _battleCanvas.gameObject.SetActive(false);
        _charaCanvas.gameObject.SetActive(true);
    }
}
