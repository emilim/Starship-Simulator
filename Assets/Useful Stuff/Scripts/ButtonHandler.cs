using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonHandler: MonoBehaviour
{
    public static bool btClick = false;

    public void btClicked()
    {
        btClick = true;
    }
    public void btNotClicked()
    {
        btClick = false;
    }
}

