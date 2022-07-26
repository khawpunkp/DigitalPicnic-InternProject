using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    
    private float _time;

    public void Awake()
    {
        if (Instance != null)
        {  
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

    private void OnEnable()
    {
        ResetTimer();
    }

    private void OnDisable()
    {
        ResetTimer();
    }
    
    public void StartTimer()
    {
        enabled = true;
    }
    
    private void ResetTimer()
    {
        _time = 0;
    }
    
    public float GetTime()
    {
        return _time;
    }
}
