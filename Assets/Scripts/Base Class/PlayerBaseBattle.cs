using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseBattle : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("エネミーデータ")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("ボタンリスト")]
    List<Button> _buttons = new();

    void Start()
    {
        StartCoroutine(WaitTime());
    }

    public void Attack()
    {
        //ボタンがActiveだったら
        _playerData.Damage(20);
        print("プレイヤーが敵に" + 20 + "与えた");
        //ボタンを非Active
        _buttons.ForEach(x => x.interactable = false);
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        _enemyData.Damage(10);
        print("敵がプレイヤーに" + 10 + "与えた");
        _buttons.ForEach(x => x.interactable = true);
        //ボタンをActive
    }
}
