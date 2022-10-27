using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PresenterBase : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    DataBase _playerData;

    [SerializeField]
    [Header("���C�t�r���[")]
    ViewBase _lifeView;

    public virtual void Start()
    {
        _playerData.Life.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
