using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewBase : MonoBehaviour
{
    public Slider HpSlider => _hpSlider;

    [SerializeField]
    [Header("HP�X���C�_�[")]
    Slider _hpSlider;

    [SerializeField]
    [Header("���O�e�L�X�g")]
    Text _logText;


    public virtual void SetLife(int lifeCount)
    {
        _hpSlider.value = lifeCount;
    }

    public virtual void SetText(string text)
    {
        _logText.text = text.ToString();
    }
}
