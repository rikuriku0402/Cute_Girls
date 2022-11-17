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
    [Header("�e��f�[�^")]
    DataBase _data;

    [SerializeField]
    [Header("�e�탉�C�t�r���[")]
    ViewBase _lifeView;

    public virtual void Start()
    {
        _data.Hp.Subscribe(hp => LifeView.SetHp(hp)).AddTo(this);
    }
}
