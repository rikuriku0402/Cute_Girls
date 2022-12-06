using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPresenter : MonoBehaviour
{
    public PlayerView LifeView => _lifeView;

    [SerializeField]
    [Header("Player�f�[�^")]
    PlayerData _data;

    [SerializeField]
    [Header("Player���C�t�r���[")]
    PlayerView _lifeView;

    public virtual void Start()
    {
        _data.Hp.Subscribe(hp => LifeView.SetHP(hp)).AddTo(this);
        _data.Mp.Subscribe(mp => LifeView.SetMP(mp)).AddTo(this);
    }
}
