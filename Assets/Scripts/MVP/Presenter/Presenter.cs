using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("Enemy Data")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("Enemy View")]
    EnemyView _enemyView;

    [SerializeField]
    [Header("Player Data")]
    PlayerData _playerData;

    [SerializeField]
    [Header("Player View")]
    PlayerView _playerView;

    #endregion

    #region Unity Method
    void Start()
    {
        _playerData.Hp.Subscribe(hp => _playerView.SetHP(hp)).AddTo(this);
        _playerData.Mp.Subscribe(mp => _playerView.SetMP(mp)).AddTo(this);
        _enemyData.Hp.Subscribe(hp => _enemyView.SetHp(hp)).AddTo(this);
    }

    #endregion
}
