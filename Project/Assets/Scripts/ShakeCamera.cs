﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public CameraShake cameraShake;

    // Update is called once per frame
    private void Update()
    {
        float currentDis = Vector3.Distance(transform.position, Camera.main.gameObject.transform.position);
        if (currentDis < 15f){
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}