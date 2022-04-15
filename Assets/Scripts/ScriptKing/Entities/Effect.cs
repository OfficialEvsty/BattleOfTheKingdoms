using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    bool IsNegative { get; set; }

    abstract void Apply();
}
