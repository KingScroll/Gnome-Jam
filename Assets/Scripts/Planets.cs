using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    public float rotateSpeedModifier = 5f;
    public float orbitSpeedModifier = 0.2f;
    public float orbitAngle = 30f;
    public Transform orbitTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, Time.deltaTime * rotateSpeedModifier, 0);
        gameObject.transform.RotateAround(orbitTarget.position, Vector3.up, orbitAngle * Time.deltaTime * orbitSpeedModifier);
    }
}
