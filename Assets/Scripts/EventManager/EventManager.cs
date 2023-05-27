using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlaceObject();

    public static event PlaceObject placeObject;
   
    public delegate void Reanchor();

    public static event Reanchor reanchor;


    #region Triggers

    public static void PlaceObjectTrigger()
    {
        if (placeObject != null)
        {
            placeObject?.Invoke();
        }
    }

    public static void ReanchorObjectTrigger()
    {
        if (reanchor != null)
        {
            reanchor?.Invoke();
        }
    }

    #endregion
}
