using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Gameplay.GameManager;
using Cinemachine;
using System;

public class CameraControl : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]private Transform defaultTarget;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>(); 
    }


    private void OnEnable()
    {
        EventManager.StartListening("ChangedTarget", OnChangedTarget);
        EventManager.StartListening("ResetTarget", OnResetTarget);
    }
    private void OnDisable()
    {
        EventManager.StopListening("ChangedTarget", OnChangedTarget);
        EventManager.StopListening("ResetTarget", OnResetTarget);
    }

    private void OnChangedTarget(object target)
    {
        virtualCamera.LookAt= (Transform)target;
        virtualCamera.m_Lens.FieldOfView = 15.6f;
    }

    private void OnResetTarget(object target)
    {
        virtualCamera.LookAt = (Transform)target;
        virtualCamera.m_Lens.FieldOfView = 60f;
    }
}
