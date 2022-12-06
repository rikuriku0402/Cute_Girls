using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    [Header("�G�f�[�^")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("�G���C�t�r���[")]
    EnemyView _enemyView;

    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�v���C���[���C�t�r���[")]
    PlayerView _playerView;

    void Start()
    {
        _playerData.Hp.Subscribe(hp => _playerView.SetHP(hp)).AddTo(this);
        _playerData.Mp.Subscribe(mp => _playerView.SetMP(mp)).AddTo(this);
        _enemyData.Hp.Subscribe(hp => _enemyView.SetHp(hp)).AddTo(this);
    }
}
