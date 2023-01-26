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

    #endregion

    #region Method

    public void SetHp(int hpCount) => _hpSlider.value = hpCount;

    #endregion
}
