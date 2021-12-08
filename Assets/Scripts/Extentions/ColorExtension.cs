using UnityEngine;

public static class ColorExtension 
{
    public static Color GetRandom(this Color color)
    {
        return new Color(Random.value, Random.value, Random.value, 1);
    }
}
