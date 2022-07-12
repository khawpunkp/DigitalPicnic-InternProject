using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInteract : MonoBehaviour
{
    [SerializeField] private GameObject _detail;
    [SerializeField] private float _areaRadius = 5f;
    
    private void Start()
    {
        GetComponent<SphereCollider>().radius = _areaRadius;
    }
    
    private void OnTriggerStay(Collider other)
    {
        _detail.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _detail.SetActive(false);
    }
}
