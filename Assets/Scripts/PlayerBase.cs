using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class PlayerBase : MonoBehaviour
{
    [Inject]
    IInputProbider _inputProvider;

    [SerializeField]
    [Header("ジャンプパワー")]
    float _jumpPower;

    [SerializeField]
    [Header("移動スピード")]
    float _speed;

    [SerializeField]
    [Header("リジッドボディ(剛体)")]
    Rigidbody2D _rb2D;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MovePlayer());
    }
    void MovePlayer()
    {
        if (_inputProvider.IsJump())
        {
            Jump();
        }
        _rb2D.velocity = new Vector3(_inputProvider.GetHorizontal(), _inputProvider.GetVertical()) * _speed;
    }

    void Jump() => _rb2D.AddForce(new Vector2(0, _jumpPower),ForceMode2D.Impulse);
}
