using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseBattle : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�G�l�~�[�f�[�^")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("�{�^�����X�g")]
    List<Button> _buttons = new();

    void Start()
    {
        StartCoroutine(WaitTime());
    }

    public void Attack()
    {
        //�{�^����Active��������
        _playerData.Damage(20);
        print("�v���C���[���G��" + 20 + "�^����");
        //�{�^�����Active
        _buttons.ForEach(x => x.interactable = false);
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        _enemyData.Damage(10);
        print("�G���v���C���[��" + 10 + "�^����");
        _buttons.ForEach(x => x.interactable = true);
        //�{�^����Active
    }
}
