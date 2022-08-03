using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;

    public bool isDisplayed = false;

    private void Start()
    {
        uiPanel.SetActive(false);
    }

    public void Show(bool active = false, string text = "")
    {
        Debug.Log("show");
        promptText.text = text;
        uiPanel.SetActive(active);
        isDisplayed = active;
    }
}
