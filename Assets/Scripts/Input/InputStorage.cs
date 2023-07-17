using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputStorage
{
    private static Vector2 move;
    public static Vector2 Move { 
        get { return move; } 
        set { move = value; } 
    }
    
    private static Vector2 mouse;
    public static Vector2 Mouse { 
        get { return mouse; } 
        set { mouse = value; } 
    }

    private static bool sprint;
    public static bool Sprint { 
        get { return sprint; } 
        set { sprint = value; } 
    }

    private static bool interact;
    public static bool Interact { 
        get { return interact; } 
        set { interact = value; } 
    }
}
