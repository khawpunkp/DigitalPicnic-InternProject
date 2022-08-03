using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
   public static Background Instance;
   
   [SerializeField] private Canvas canvas;
   [SerializeField] private GameObject player;
   
   private RectTransform bgRect;

   private Vector2 startPos;
   
   public float speed = 50f;
   
   public float maxX;
   public float minX;
   public float maxY;
   public float minY;

   public Vector3 cvScale;
   
   public void Awake()
   {
      cvScale = canvas.transform.localScale;
      if (Instance != null && Instance != this) 
      { 
         Destroy(this); 
      } 
      else 
      { 
         Instance = this; 
      }
   }
   
   
   // Start is called before the first frame update
   void Start()
   {
      var cvRect = canvas.GetComponent<RectTransform>().rect;
      
      bgRect = GetComponent<RectTransform>();
      startPos = GetComponent<RectTransform>().anchoredPosition;

      var rect = bgRect.rect;
      var playerRect = player.GetComponent<RectTransform>().rect;
      var offset = 10f;
      
      maxX = (((cvRect.width + rect.width) - playerRect.width)/2 - offset) * cvScale.x;
      minX = (((cvRect.width - rect.width) + playerRect.width)/2 + offset) * cvScale.x;
      maxY = (cvRect.height - playerRect.height/2 - offset) * cvScale.y;
      minY = ((0 + playerRect.height)/2 + offset) * cvScale.y;
   }

   // Update is called once per frame
   void Update()
   {
      transform.Translate(Vector3.down * Time.deltaTime * speed);
      if (bgRect.anchoredPosition.y < - bgRect.rect.height / 4)
      {
         bgRect.anchoredPosition = startPos;
      }
   }
}
