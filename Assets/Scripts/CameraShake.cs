using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.7f;   // Duration of the camera shake
    public float shakeIntensity = 0.7f;  // Intensity of the camera shake

    private Vector3 originalPosition;    // Original position of the camera
    private float currentShakeDuration;  // Current duration of the camera shake

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {

            // Generate a random offset within a sphere
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;

            // Apply the offset to the camera's position
            transform.localPosition = originalPosition + shakeOffset;

            // Reduce the remaining shake duration
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            // Reset the camera position
            transform.localPosition = originalPosition;
        }
    }

    public void ShakeCamera(float duration = 0)
    {
        if (duration > 0)
        {
            currentShakeDuration = duration;
        } else
        {
            currentShakeDuration = shakeDuration;
        }
        
    }
}