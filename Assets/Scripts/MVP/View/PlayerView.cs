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

    //[SerializeField]
    //[Header("���O�e�L�X�g")]
    //Text _logText;


    public void SetHp(int hpCount) => _hpSlider.value = hpCount;

    public void SetMP(int mpCount) => _mpSlider.value = mpCount;

}
