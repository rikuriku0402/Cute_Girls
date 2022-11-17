using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeView : ViewBase
{
    public Slider MpSlider => _mpSlider;

    [SerializeField]
    [Header("MP�X���C�_�[")]
    Slider _mpSlider;

    private void Start()
    {
        print(HpSlider.value);
    }


    public virtual void SetMp(int mpCount) => _mpSlider.value = mpCount;
}
