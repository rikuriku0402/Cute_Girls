using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("移動スピード")]
    private float _speed;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    [Inject]
    private IInputProbider _inputProvider;

    private Animator _animator;

    private Rigidbody2D _rb;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MovePlayer()).AddTo(this);
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IGoal goal))
        {
            goal.GoalClear();
            _rb.velocity = new();
            _animator.SetBool("Run", false);
            GameManager.Instance.ChangeGameMode(false);
            _soundManager.PlayBGM(BGMType.GameClear);
        }

        if (collision.TryGetComponent(out IBattle enemy))
        {
            enemy.GetBattle(_uiManager.BattleCanvas.gameObject);
            _rb.velocity = new();
            _animator.SetBool("Run", false);
            GameManager.Instance.ChangeGameMode(false);
            _soundManager.PlayBGM(BGMType.Battle);
        }
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
}
