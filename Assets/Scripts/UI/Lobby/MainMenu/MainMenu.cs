using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("menu active");
        gameObject.SetActive(true);
    }
}
