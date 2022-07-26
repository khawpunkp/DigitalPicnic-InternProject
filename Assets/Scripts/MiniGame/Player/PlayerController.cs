using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private RectTransform background;
    [SerializeField] private float offset = 10f;

    private float maxX;
    private float minX;
    private float maxY;
    private float minY;
    void Start()
    {
        var bgRect = background.rect;
        var playerRect = GetComponent<RectTransform>().rect;

        maxX = ((1920 + bgRect.width) - playerRect.width)/2 - offset;
        minX = ((1920 - bgRect.width) + playerRect.width)/2 + offset;
        maxY = 1080 - playerRect.height/2 - offset;
        minY = 0 + playerRect.height/2 + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
        targetPos.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
