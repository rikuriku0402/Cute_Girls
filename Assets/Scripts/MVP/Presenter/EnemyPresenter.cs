using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class EnemyPresenter : MonoBehaviour
{
    public EnemyView LifeView => _lifeView;

    [SerializeField]
    [Header("各種データ")]
    EnemyData _data;

    [SerializeField]
    [Header("各種ライフビュー")]
    EnemyView _lifeView;

    public virtual void Start()
    {
        _data.Hp.Subscribe(hp => LifeView.SetHp(hp)).AddTo(this);
    }
}
