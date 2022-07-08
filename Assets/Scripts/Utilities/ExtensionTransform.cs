using UnityEngine;

public static class Transforms
{
    public static void DestroyChildren(this Transform transform, bool immediately = false)
    {
        foreach (Transform t in transform)
        {
            if(immediately)
                MonoBehaviour.DestroyImmediate(t.gameObject);
            else
                MonoBehaviour.Destroy(t.gameObject);
        }
    }
}