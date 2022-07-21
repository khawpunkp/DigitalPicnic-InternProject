using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private RectTransform background;

    private float maxX;
    private float minX;
    private float maxY;
    private float minY;
    void Start()
    {
        var bgRect = background.rect;
        var playerRect = GetComponent<RectTransform>().rect;

        maxX = (1920/2 + bgRect.width/2) - playerRect.width/2 - 10;
        minX = (1920/2 - bgRect.width/2) + playerRect.width/2 + 10;
        maxY = 1080 - playerRect.height/2 - 10;
        minY = 0 + playerRect.height/2 + 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
        targetPos.z = 0f;
        Debug.Log(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
