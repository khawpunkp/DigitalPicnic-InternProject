using UnityEngine;

public class EnemyRotating : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f,5f * speed * Time.deltaTime);
    }
}
