using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using System;

public class WalkBase : MonoBehaviour
{
    [SerializeField]
    [Header("移動スピード")]
    private float _speed;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    [Inject]
    private IInputProbider _inputProvider;

    private Animator _animator;

    private Rigidbody2D _rb;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MovePlayer());
        TryGetComponent(out _animator);
        TryGetComponent(out _rb);
    }

    void MovePlayer()
    {
        if (GameManager.Instance.IsGame)
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
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IGoal goal))
        {
            goal.GoalClear();
        }

        if (collision.TryGetComponent(out IBattle enemy))
        {
            enemy.GetBattle(_uiManager.BattleCanvas.gameObject);
            _rb.velocity = new();
            _animator.SetBool("Run", false);
            GameManager.Instance.ChangeGameMode(false);
        }
    }
}
