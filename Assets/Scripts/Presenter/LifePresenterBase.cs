using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifePresenterBase : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    HpDataBase _playerData;

    [SerializeField]
    [Header("���C�t�r���[")]
    LifeViewBase _lifeView;

    public virtual void Start()
    {
        _playerData.Life.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
