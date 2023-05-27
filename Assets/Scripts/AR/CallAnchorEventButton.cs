using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnchorEventButton : MonoBehaviour
{
    public void CallAnchorEvent()
    {
        EventManager.PlaceObjectTrigger();
    }

    public void CallReanchorEvent()
    {
        EventManager.ReanchorObjectTrigger();
    }
}
