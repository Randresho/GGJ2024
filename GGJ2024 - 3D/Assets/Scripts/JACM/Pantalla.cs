using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    Color lerpedColor = Color.white;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.red*4, Color.blue*4, Mathf.PingPong(Time.time, .5f));
        renderer.material.SetColor("_EmissionColor", lerpedColor);
    }
}
