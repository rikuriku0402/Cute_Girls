using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerCamera : MonoBehaviour
{
    Transform _playerTransform;

    [SerializeField]
    [Header("追従したいオブジェクト")]
    GameObject _player;

    void Start()
    {
        _playerTransform = _player.transform;
        this.LateUpdateAsObservable().Subscribe(x => MoveCamera());
    }

    void MoveCamera()
    {
        // 横方向だけ追従
        transform.position = new Vector3(_playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
