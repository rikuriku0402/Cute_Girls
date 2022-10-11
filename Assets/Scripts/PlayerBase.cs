using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("�X�s�[�h")]
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

        // �E���͂ō��ɓ���
        if (horizontalKey > 0)
        {
            _rb2D.velocity = new Vector2(_speed, _rb2D.velocity.y);
        }
        // �����͂ŉE�ɓ���
        else if (horizontalKey < 0)
        {
            _rb2D.velocity = new Vector2(-_speed, _rb2D.velocity.y);
        }
        // �{�^����b���Ǝ~�܂�
        else
        {
            _rb2D.velocity = Vector2.zero;
        }

    }
}
