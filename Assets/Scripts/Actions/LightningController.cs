using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightningController : MonoBehaviour
{
    public static event Action OnLightingDiscovered;

    public float lightningDuration = .2f;
    public float currentLightingDuration = 0f;
    public Vector3Int lightningLocation = new Vector3Int(0, 0, 2);
    public IsometricRuleTile lightningTile;

    public Tilemap tilemap;

    private AudioSource audioSource;
    private bool effectTriggered = false;

    private static bool hasDiscoveredFire;

    private void Start()
    {
        if (tilemap == null)
        {
            tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        }
    }

    void Update()
    {
        HandleLightning();
        CheckDestroy();
    }

    void HandleLightning()
    {
        if (currentLightingDuration > 0)
        {
            tilemap.SetTile(lightningLocation, lightningTile);
            currentLightingDuration -= Time.deltaTime;
        }
        else
        {
            tilemap.SetTile(lightningLocation, null);
        }
    }

    public void OnLighting(Vector3Int position)
    {
        currentLightingDuration = lightningDuration;
        lightningLocation = position;
        Camera.main.GetComponent<CameraShake>().ShakeCamera(.2f);
        GetComponent<AudioSource>().Play();
        effectTriggered = true;
        if (!hasDiscoveredFire)
        {
            hasDiscoveredFire = true;
            OnLightingDiscovered?.Invoke();
        }
        
    }

    private void CheckDestroy()
    {
        if (effectTriggered && !GetComponent<AudioSource>().isPlaying && !(currentLightingDuration > 0))
        {
            Destroy(gameObject);
        }
    }
}
