using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float speed = 10f;
    [SerializeField] private RectTransform background;
    [SerializeField] private float offset = 10f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Background bg;
    private Vector3 cvScale;
    
    // private float maxX;
    // private float minX;
    // private float maxY;
    // private float minY;
    void Start()
    {
        // var cvRect = canvas.GetComponent<RectTransform>().rect;
        cvScale = canvas.transform.localScale;
        //
        // var bgRect = background.rect;
        // var playerRect = GetComponent<RectTransform>().rect;

        // maxX = (((cvRect.width + bgRect.width) - playerRect.width)/2 - offset) * cvScale.x;
        // minX = (((cvRect.width - bgRect.width) + playerRect.width)/2 + offset) * cvScale.x;
        // maxY = (cvRect.height - playerRect.height/2 - offset) * cvScale.y;
        // minY = ((0 + playerRect.height)/2 + offset) * cvScale.y;
        //
        // maxX = ((1920 + bgRect.width) - playerRect.width)/2 - offset;
        // minX = ((1920 - bgRect.width) + playerRect.width)/2 + offset;
        // maxY = 1080 - playerRect.height/2 - offset;
        // minY = 0 + playerRect.height/2 + offset;
    }

    // Update is called once per frame
    void Update()
    { 
        var timePlayed = TimeManager.Instance.GetTime();
        speed = Mathf.RoundToInt(speedCurve.Evaluate(timePlayed)) * 100 * cvScale.x;
        Vector3 targetPos = Input.mousePosition;
        targetPos.x = Mathf.Clamp(targetPos.x, bg.minX, bg.maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, bg.minY, bg.maxY);
        targetPos.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    
    
}
