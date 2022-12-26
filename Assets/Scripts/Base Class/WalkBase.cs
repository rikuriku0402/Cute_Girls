using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class WalkBase : MonoBehaviour
{
    Animator _animator;

    Rigidbody2D _rb;

    [Inject]
    IInputProbider _inputProvider;

    [SerializeField]
    [Header("移動スピード")]
    float _speed;

    [SerializeField]
    [Header("Enemy Canvas")]
    GameObject _enemyCanvas;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MovePlayer());
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void MovePlayer()
    {
        if (_inputProvider.IsAttack())
        {
            Attack();
        }
        if (_inputProvider.GetHorizontal() < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _animator.SetBool("Run", true);
        }
        else if (_inputProvider.GetHorizontal() > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
        _rb.velocity = new Vector3(_inputProvider.GetHorizontal(), _inputProvider.GetVertical()) * _speed;
    }

    void Attack() => _animator.SetTrigger("Attack");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IGoal goal))
        {
            goal.GoalClear();
        }
        if (collision.TryGetComponent(out IBattle enemy))
        {
            enemy.GetBattle(_enemyCanvas);
            _speed = 0f;
            Destroy(collision.gameObject);
        }
    }
}
