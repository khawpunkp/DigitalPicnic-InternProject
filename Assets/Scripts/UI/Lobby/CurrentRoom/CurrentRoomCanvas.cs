using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI _roomID;
    
    private RoomCanvas _roomCanvas;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void FirstInitailize(RoomCanvas canvas)
    {
        _roomCanvas = canvas;
    }

    public void Show(bool active)
    {
        gameObject.SetActive(active);
    }
}
