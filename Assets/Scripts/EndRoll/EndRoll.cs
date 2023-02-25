using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;

public class EndRoll : MonoBehaviour
{
    const string TITLE_SCENE_NAME = "Title";

    [SerializeField]
    [Header("�X�N���[���X�s�[�h")]
    private float _textScrollSpeed = 30;

    [SerializeField]
    [Header("�e�L�X�g�̐����ʒu")]
    private float _limitPos = 730f;

    [SerializeField]
    [Header("SceneLoader")]
    private SceneLoader _sceneLoader;

    private BoolReactiveProperty _isEnd = new();

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MoveEndRoll()).AddTo(this);
        NextScene();
    }

    private void MoveEndRoll()
    {
        if (!_isEnd.Value)
        {
            ////�@�G���h���[���p�e�L�X�g�����~�b�g���z����܂œ�����
            if (transform.position.y <= _limitPos)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + _textScrollSpeed * Time.deltaTime);
            }
            else
            {
                _isEnd.Value = true;
                Debug.Log(_isEnd.Value);
            }
        }
    }

    private void NextScene()
    {
        _isEnd.ObserveEveryValueChanged(x => x.Value).Subscribe
            (x =>
            {
                if (_isEnd.Value)
                {
                    Debug.Log("��");
                    _sceneLoader.FadeInSceneChange(TITLE_SCENE_NAME);
                }
            }).AddTo(this);
    }
}
