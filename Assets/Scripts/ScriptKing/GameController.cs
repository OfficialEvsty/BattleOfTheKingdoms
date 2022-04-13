using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject _constructionObject;

    private PropertyConstruction _propertyConstruction;

    //private void Update()
    //{
    //    Action();
    //}

    //private void Action()
    //{
    //    if(ChoiceConstruction())
    //    {
    //        Vector3 clickPosition = GetClickMousePosition();
    //        //Debug.Log(clickPosition);
    //        //Transform clickedCounstruction = GetPropConstructions(clickPosition);
    //        //Debug.Log(clickedCounstruction);
    //        if (clickedCounstruction == null)
    //            return;

    //        _propertyConstruction.OpenPanelConstruction(clickedCounstruction.name);
    //    }
    //}

    private Transform GetPropConstructions(Vector3 position)
    {
        //RaycastHit hit;
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //    if (affectedConstructions.Length == 0)
        //    return null;
        //return affectedConstructions[0].transform;
        throw new NotImplementedException();
    }

    private Vector3 GetClickMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool ChoiceConstruction()
    {
        return Input.GetMouseButton(0);
    }


}
