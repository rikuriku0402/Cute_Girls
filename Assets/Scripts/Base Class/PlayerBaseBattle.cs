using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PlayerBaseBattle : MonoBehaviour
{
    ActionEnum _type;


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
        _enemyData.Damage(_playerAttack);
        print("プレイヤーが敵に" + _playerAttack + "与えた");
        //ボタンを非Active
        _buttons.ForEach(x => x.interactable = false);
        _type = ActionEnum.Attack;
        StartCoroutine(WaitTime());
    }

    public void Defance()
    {
        _buttons.ForEach(x => x.interactable = false);
        _type = ActionEnum.Defense;
        StartCoroutine(WaitTime());
    }


    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(2f);
        switch (_type)
        {
            case ActionEnum.Attack:
                _playerData.Damage(_enemyAttack);
                print("敵がプレイヤーに" + _enemyAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
        //ボタンをActive
                break;
            case ActionEnum.Defense:
                int allAttack = _enemyAttack - _defence;
                _playerData.Damage(allAttack);
                print("敵がプレイヤーに" + allAttack + "与えた");
                _buttons.ForEach(x => x.interactable = true);
                break;
        }
    }
}
