using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("スピード")]
    float _speed;

    Rigidbody2D _rb2D;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        this.FixedUpdateAsObservable().Subscribe(x => Move());
    }

    void Move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        // 右入力で左に動く
        if (horizontalKey > 0)
        {
            _rb2D.velocity = new Vector2(_speed, _rb2D.velocity.y);
        }
        // 左入力で右に動く
        else if (horizontalKey < 0)
        {
            _rb2D.velocity = new Vector2(-_speed, _rb2D.velocity.y);
        }
        // ボタンを話すと止まる
        else
        {
            _rb2D.velocity = Vector2.zero;
        }

    }
}
