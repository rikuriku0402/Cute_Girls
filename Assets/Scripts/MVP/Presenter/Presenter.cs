using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    [Header("敵データ")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("敵ライフビュー")]
    EnemyView _enemyView;

    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("プレイヤーライフビュー")]
    PlayerView _playerView;

    void Start()
    {
        _playerData.Hp.Subscribe(hp => _playerView.SetHP(hp)).AddTo(this);
        _playerData.Mp.Subscribe(mp => _playerView.SetMP(mp)).AddTo(this);
        _enemyData.Hp.Subscribe(hp => _enemyView.SetHp(hp)).AddTo(this);
    }
}
