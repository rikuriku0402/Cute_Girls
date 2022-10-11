using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProbider
{
    bool IsJump();

    float GetHorizontal();

    float GetVertical();

}
