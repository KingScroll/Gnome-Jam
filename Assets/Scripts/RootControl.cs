using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootControl : MonoBehaviour
{
    Renderer renderer;
    float fillValue;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        fillValue = renderer.material.GetFloat("_Fill");
    }

    public void UpdateFillValue(float input)
    {
        fillValue = input;
        renderer.material.SetFloat("_Fill", fillValue);
    }
}
