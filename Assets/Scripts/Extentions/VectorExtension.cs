using UnityEngine;

public static class VectorExtension 
{
    public static Vector3 GetRandomPosition(this Vector3 vector3, Vector3 relativePos)
    {
        return new Vector3(relativePos.x + Random.Range((-(Screen.width / 2) / 100), ((Screen.width / 2) / 100)), relativePos.y, 0);
    }
}
