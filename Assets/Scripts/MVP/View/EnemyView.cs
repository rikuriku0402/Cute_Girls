using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("HP Slider")]
    private Slider _hpSlider;

    [SerializeField]
    [Header("MPテキスト")]
    private Text _hpText;
    #endregion

    #region Method

    public void SetHp(int hp)
    {
        _hpSlider.value = hp;
        _hpText.text = hp.ToString() + "/" + _hpSlider.maxValue;
        if (hp <= 0)
        {
            _hpText.text = 0 + "/" + _hpSlider.maxValue;
        }
    }

    #endregion
}
