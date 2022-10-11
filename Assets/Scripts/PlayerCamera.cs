using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerCamera : MonoBehaviour
{
    Transform _playerTransform;

    [SerializeField]
    [Header("�Ǐ]�������I�u�W�F�N�g")]
    GameObject _player;

    void Start()
    {
        _playerTransform = _player.transform;
        this.LateUpdateAsObservable().Subscribe(x => MoveCamera());
    }

    void MoveCamera()
    {
        // �����������Ǐ]
        transform.position = new Vector3(_playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
