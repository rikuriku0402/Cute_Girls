using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    [Header("HPスライダー")]
    Slider _hpSlider;

    [SerializeField]
    [Header("MPスライダー")]
    Slider _mpSlider;

    //[SerializeField]
    //[Header("ログテキスト")]
    //Text _logText;


    public void SetHp(int hpCount) => _hpSlider.value = hpCount;

    public void SetMP(int mpCount) => _mpSlider.value = mpCount;

}
