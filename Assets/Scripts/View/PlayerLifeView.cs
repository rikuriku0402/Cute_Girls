using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeView : ViewBase
{
    public Slider MpSlider => _mpSlider;

    [SerializeField]
    [Header("MPスライダー")]
    Slider _mpSlider;

    private void Start()
    {
        print(HpSlider.value);
    }


    public virtual void SetMp(int mpCount) => _mpSlider.value = mpCount;
}
