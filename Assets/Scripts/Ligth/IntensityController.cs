//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IntensityController : MonoBehaviour
{
    public float minIntensity;
    public float maxIntensity;
    public float timeBetweenIntensityChanges;

    private Light2D lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light2D>();
        InvokeRepeating("ChangeIntensity", 0.0f, timeBetweenIntensityChanges);
    }

    void ChangeIntensity()
    {
        float newIntensity = Random.Range(minIntensity, maxIntensity);
        lightComponent.intensity = newIntensity;
    }
}
