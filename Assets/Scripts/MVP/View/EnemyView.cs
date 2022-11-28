using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    [Header("HP�X���C�_�[")]
    Slider _hpSlider;

    //[SerializeField]
    //[Header("���O�e�L�X�g")]
    //Text _logText;


    public void SetHp(int hpCount) => _hpSlider.value = hpCount;

    //public virtual void SetText(string text)
    //{
    //    _logText.text = text.ToString();
    //}
}
