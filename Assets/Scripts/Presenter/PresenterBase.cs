using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PresenterBase : MonoBehaviour
{
    public DataBase Data => _data;

    public ViewBase LifeView => _lifeView;

    CharacterType _type;

    [SerializeField]
    [Header("各種データ")]
    DataBase _data;

    [SerializeField]
    [Header("各種ライフビュー")]
    ViewBase _lifeView;

    public virtual void Start()
    {
        _data.Hp.Subscribe(hp => LifeView.SetHp(hp)).AddTo(this);
    }
}
