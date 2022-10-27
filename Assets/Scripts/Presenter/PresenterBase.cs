using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PresenterBase : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    DataBase _playerData;

    [SerializeField]
    [Header("ライフビュー")]
    ViewBase _lifeView;

    public virtual void Start()
    {
        _playerData.Life.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
