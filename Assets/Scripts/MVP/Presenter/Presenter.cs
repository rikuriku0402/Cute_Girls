using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("Enemy Data")]
    private EnemyData _enemyData;

    [SerializeField]
    [Header("Enemy View")]
    private EnemyView _enemyView;

    [SerializeField]
    [Header("Player Data")]
    private PlayerData _playerData;

    [SerializeField]
    [Header("Player View")]
    private PlayerView _playerView;

    #endregion

    #region Unity Method
    private void Start()
    {
        _playerData.Hp.Subscribe(hp => _playerView.SetHP(hp)).AddTo(this);
        _playerData.Mp.Subscribe(mp => _playerView.SetMP(mp)).AddTo(this);
        _enemyData.Hp.Subscribe(hp => _enemyView.SetHp(hp)).AddTo(this);
    }

    #endregion
}
