using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
   private RectTransform bgPos;

   private Vector2 startPos;
   // Start is called before the first frame update
   void Start()
   {
      bgPos = GetComponent<RectTransform>();
      startPos = GetComponent<RectTransform>().anchoredPosition;
   }

   // Update is called once per frame
   void Update()
   {
      if (bgPos.anchoredPosition.y < -540)
      {
         bgPos.anchoredPosition = startPos;
      }
   }
}
