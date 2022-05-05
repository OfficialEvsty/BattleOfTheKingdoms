using System.Collections.Generic;
using UnityEngine;

public abstract class Dice
{
    public abstract int GetResult(List<SideOfTheDice> SideOfTheDice, Vector3 diceVelocity);

    public abstract void Trhow(Transform transform, Rigidbody rigidbody, float powerMultiplier/*, Quaternion quaternion*/);

}
