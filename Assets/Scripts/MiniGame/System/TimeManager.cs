using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    
    private float _time;

    public void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    private void Start()
    {
        enabled = false;
    }
    
    private void Update()
    {
        if (enabled)
        {
            _time += Time.deltaTime;
        }
    }
    
    public void StartTimer()
    {
        _time = 0;
        enabled = true;
    }
    
    public float GetTime()
    {
        return _time;
    }
}
