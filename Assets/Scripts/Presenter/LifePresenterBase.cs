using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifePresenterBase : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    HpDataBase _playerData;

    [SerializeField]
    [Header("ライフビュー")]
    LifeViewBase _lifeView;

    public virtual void Start()
    {
        _playerData.Life.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
