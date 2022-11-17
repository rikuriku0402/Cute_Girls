using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class BattleManager : MonoBehaviour
{
    bool _isPortion;

    ActionType _actionType;

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
    [Header("ポーションの攻撃力")]
    int _portionAttack;

    [SerializeField]
    [Header("使用MP")]
    int _portionMp;

    [SerializeField]
    [Header("敵の攻撃力")]
    int _enemyAttack;

    [SerializeField]
    [Header("ログテキスト")]
    Text _logText;

    private void Start()
    {
        _isPortion = true;
        this.UpdateAsObservable().Subscribe(x => LifeCheck());
    }

    void LifeCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            GameManager.GameOver();
        }
        if (_enemyData.Hp.Value <= 0)
        {
            GameManager.GameClear();
        }
    }

    void MPCheck()
    {
        if (_portionMp <= 0)
        {
            _isPortion = false;
        }
    }

    public void Attack()
    {
        //ボタンがActiveだったら
        _enemyData.HpDamage(_playerAttack);
        print("プレイヤーが敵に" + _playerAttack + "与えた");
        // テキストにダメージ量とかを出す
        _logText.text = "プレイヤーが敵に" + _playerAttack + "与えた";
        //ボタンを非Active
        _buttons.ForEach(x => x.interactable = false);
        _actionType = ActionType.Attack;
        StartCoroutine(WaitTime());
    }

    public void Defance()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "防御する";
        _actionType = ActionType.Defense;
        StartCoroutine(WaitTime());
    }

    public void Portion()
    {
        if (_isPortion)
        {
            _enemyData.HpDamage(_portionAttack);
            _playerData.MpDamage(_portionMp);
            print("プレイヤーが敵に" + _portionAttack + "与えた");
            _logText.text = "プレイヤーが敵に" + _portionAttack + "与えた";
            _buttons.ForEach(x => x.interactable = false);
            _actionType = ActionType.Portion;
            StartCoroutine(WaitTime());
            MPCheck();
        }
        else
        {
            _logText.text = "MPが足りないよ";
        }
    }

    /// <summary>
    /// 連打防止
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        _logText.text = null;
        int allAttack = 0;

        switch (_actionType)
        {
            case ActionType.Attack:
                _playerData.HpDamage(_enemyAttack);
                print("敵がプレイヤーに" + _enemyAttack + "与えた");
                //ボタンをActive
                break;

            case ActionType.Defense:
                allAttack = _enemyAttack - _defence;
                _playerData.HpDamage(allAttack);
                print("敵がプレイヤーに" + allAttack + "与えた");
                break;

            case ActionType.Portion:
                allAttack = _enemyAttack + _enemyAttack;
                _playerData.HpDamage(allAttack);
                print("敵がプレイヤーに" + allAttack + "与えた");
                break;

            case ActionType.Recovery:
                // MP回復スキル
                break;

            case ActionType.HpRecvery:
                // HP回復スキル
                break;
        }
        _buttons.ForEach(x => x.interactable = true);
    }
}
