using UnityEngine;

public abstract class ScriptableObjectSingleton<SO> : ScriptableObject where SO : ScriptableObject
{
    private static SO _instance = null;

    public static SO Instance
    {
        get
        {
            if (_instance == null)
            {
                SO[] results = Resources.FindObjectsOfTypeAll<SO>();

                if (results.Length == 0)
                {
                    Debug.Log("Results length is 0 for type " + typeof(SO) + ".");
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.Log("Results length is greater than 1 for type " + typeof(SO) + ".");
                    return null;
                }

                _instance = results[0];
            }

            return _instance;
        }
    }
}
