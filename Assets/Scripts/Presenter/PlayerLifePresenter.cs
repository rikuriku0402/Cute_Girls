using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerLifePresenter : PresenterBase
{
    [SerializeField]
    [Header("���C�t�r���[")]
    PlayerLifeView _lifeView;

    public override void Start()
    {
        base.Start();
        Data.Mp.Subscribe(mp => _lifeView.SetMp(mp)).AddTo(this);
    }
}
