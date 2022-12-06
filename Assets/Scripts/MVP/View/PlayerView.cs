using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    [Header("HP�X���C�_�[")]
    Slider _hpSlider;

    [SerializeField]
    [Header("MP�X���C�_�[")]
    Slider _mpSlider;

    public void SetHP(int hpCount) => _hpSlider.value = hpCount;

    public void SetMP(int mpCount) => _mpSlider.value = mpCount;

}
