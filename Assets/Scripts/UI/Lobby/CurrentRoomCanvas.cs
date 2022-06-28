using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI _roomID;
    
    private RoomCanvas _roomCanvas;

    public void FirstInitailize(RoomCanvas canvas)
    {
        _roomCanvas = canvas;
    }

    public void Show(bool active)
    {
        gameObject.SetActive(active);
    }
}
