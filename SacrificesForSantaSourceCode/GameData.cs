using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static int levels;

    public static int Levels
    {
        get
        {
            return levels;
        }
        set
        {
            levels = value;
        }
    }

}
