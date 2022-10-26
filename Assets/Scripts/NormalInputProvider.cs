using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalInputProvider : IInputProbider
{
    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public bool IsAttack()
    {
        return Input.GetMouseButtonDown(0);
    }
}
