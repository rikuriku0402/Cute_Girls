using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

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

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(x => LifeCheck());
    }

    void LifeCheck()
    {
        if (_playerData.Life.Value <= 0)
        {
            GameManager.GameOver();
        }
        if (_enemyData.Life.Value <= 0)
        {
            GameManager.GameClear();
        }
    }

    public void Attack()
    {
        //ボタンがActiveだったら
        _playerData.GetDamage(_enemyAttack);
        print("プレイヤーが敵に" + _enemyAttack + "与えた");
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
                _enemyData.GetDamage(_playerAttack);
                print("敵がプレイヤーに" + _playerAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
        //ボタンをActive
                break;
            case AttackEnum.Defense:
                int allAttack = _playerAttack - _defence;
                _enemyData.GetDamage(allAttack);
                print("敵がプレイヤーに" + allAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
                break;
        }
    }
}
