using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;

    public bool isDisplayed = false;

    private void Start()
    {
        mainCamera = Camera.main;
        uiPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.zero);
    }

    public void Show(bool active = false, string text = "")
    {
        Debug.Log("show");
        promptText.text = text;
        uiPanel.SetActive(active);
        isDisplayed = active;
    }
}
