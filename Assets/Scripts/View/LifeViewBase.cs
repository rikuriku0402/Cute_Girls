using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeViewBase : MonoBehaviour
{
    public Slider HpSlider => _hpSlider;

    [SerializeField]
    [Header("HP�X���C�_�[")]
    Slider _hpSlider;

    bool _;

    public virtual void SetLife(int lifeCount)
    {
        _hpSlider.value = lifeCount;
    }
}
