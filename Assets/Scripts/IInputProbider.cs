using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProbider
{
    float GetHorizontal();

    float GetVertical();

    bool IsAttack();

}
