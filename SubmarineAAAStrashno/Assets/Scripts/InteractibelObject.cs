using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibelObject : Interactible
{
    public override void OnFocus()
    {
        print("Looking AT" + gameObject.name);
    }

    public override void OnInteract()
    {
        print("Interacting With" + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stopped Looking AT" + gameObject.name);
    }
}
