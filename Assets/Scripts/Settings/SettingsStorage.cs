using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsStorage
{
    private static float sen;
    private static float senX;
    private static float senY;

    public static float Sen {
        get { return sen; }
        set { sen = value; }
    }

    public static float SenX {
        get { return senX; }
        set { senX = value; }
    }

    public static float SenY {
        get { return senY; }
        set { senY = value; }
    }

    public static void SetToDefault() {
        Sen = 0.5f;
        SenX = 0.5f;
        SenY = 0.5f;
    }
}
