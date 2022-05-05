using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicOfDice : Dice
{

    public override int GetResult(List<SideOfTheDice> SideOfTheDice, Vector3 diceVelocity)
    {

        float maxTransform = -1f;
        foreach (var item in SideOfTheDice)
        {
            if (item.transform.position.y >= maxTransform)
                maxTransform = item.transform.position.y;
        };

        foreach (var item in SideOfTheDice)
        {
            if (item.transform.position.y == maxTransform)
                return item.i_effectiveNumber;
        }

        return 0;

        //if (diceVelocity.x == 0f &&
        //    diceVelocity.y == 0f &&
        //    diceVelocity.z == 0f)
        //{
        //    switch (collider.gameObject.name)
        //    {
        //        case "SideUp1":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 1;
        //            return 1;
        //        case "SideUp2":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 2;
        //            return 2;
        //        case "SideUp3":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 3;
        //            return 3;
        //        case "SideUp4":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 4;
        //            return 4;
        //        case "SideUp5":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 5;
        //            return 5;
        //        case "SideUp6":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 6;
        //            return 6;
        //        case "SideDown7":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 7;
        //            return 7;
        //        case "SideDown8":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 8;
        //            return 8;
        //        case "SideDown9":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 9;
        //            return 9;
        //        case "SideDown10":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 10;
        //            return 10;
        //        case "SideDown11":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 11;
        //            return 11;
        //        case "SideDown12":
        //            //ResultOfTheThrow.m_resultOfTheThrow = 12;
        //            return 12;
        //        default:
        //            return 0;
        //    }
        //}
        //else
        //    return 0;
    }

    public override void Trhow(Transform transform, Rigidbody rigidbody, float powerMultiplier/*, Quaternion quaternion*/)
    {
        //ResultOfTheThrow.m_resultOfTheThrow = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        //transform.rotation = /*quaternion*/ Quaternion.identity;
        rigidbody.AddForce(transform.forward * 1000 * powerMultiplier);
        rigidbody.AddTorque(dirX, dirY, dirZ);
    }
}
