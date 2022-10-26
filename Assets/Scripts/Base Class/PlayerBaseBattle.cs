using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseBattle : MonoBehaviour
{
    AttackEnum _type;


    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("エネミーデータ")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("ボタンリスト")]
    List<Button> _buttons = new();

    [SerializeField]
    [Header("ディフェンス")]
    int _defence;

    [SerializeField]
    [Header("プレイヤーの攻撃力")]
    int _playerAttack;

    [SerializeField]
    [Header("敵の攻撃力")]
    int _enemyAttack;

    void Start()
    {
    }

    public void Attack()
    {
        //ボタンがActiveだったら
        _playerData.AddDamage(_playerAttack);
        print("プレイヤーが敵に" + _playerAttack + "与えた");
        //ボタンを非Active
        _buttons.ForEach(x => x.interactable = false);
        _type = AttackEnum.Attack;
        StartCoroutine(WaitTime());
    }

    public void Defance()
    {
        _buttons.ForEach(x => x.interactable = false);
        _type = AttackEnum.Defense;
        StartCoroutine(WaitTime());
    }


    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(2f);
        switch (_type)
        {
            case AttackEnum.Attack:
                _enemyData.AddDamage(_enemyAttack);
                print("敵がプレイヤーに" + _enemyAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
        //ボタンをActive
                break;
            case AttackEnum.Defense:
                int allAttack = _enemyAttack - _defence;
                _enemyData.AddDamage(allAttack);
                print("敵がプレイヤーに" + allAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
                break;
        }
    }
}
