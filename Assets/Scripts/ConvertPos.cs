using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertPos
{
    public static Vector3 UnityToScreen(Vector3 unityPos)
    {
        float x = unityPos.x;
        float y = unityPos.y;
        Vector3 result = new Vector3(x*100, y*100, 0);
        return result;
    }

    public static Vector3 ScreenToUnity(Vector3 screenPos)
    {
        float x = screenPos.x;
        float y = screenPos.y;
        Vector3 result = new Vector3(x/100, y/100, 0);
        return result;
    }

    public static Vector3 NearestBlock(Vector3 pos)
    {
        float x = pos.x;
        float y = pos.y;
        Vector3 result = new Vector3(Mathf.Round(x), Mathf.Round(y+0.5f)-0.5f, 0);
        return result;
    }
}
