using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeeds : MonoBehaviour
{
    public Transform spawnPoint;
    public int gridIndex;
    public GridArray parentGridArray;
    Rigidbody rb;

    float distanceFromSpawn;
    Vector3 normalScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalScale = gameObject.transform.lossyScale;
        parentGridArray = GetComponentInParent<GridArray>();
        if(parentGridArray != null)
        {
            gridIndex = parentGridArray.gridTransforms.IndexOf(spawnPoint);
        }
        
    }

    private void Update()
    {
        /*distanceFromSpawn = Vector3.Distance(spawnPoint.position, gameObject.transform.position);
        if (distanceFromSpawn < 5)
        {
            gameObject.transform.localScale += new Vector3(normalScale.x, normalScale.y + distanceFromSpawn, normalScale.z);
        }*/
    }

    public void WeedSelected()
    {
        rb.isKinematic = false; // doesn't work
    }

    public void WeedBeGone()
    {
        rb.constraints = RigidbodyConstraints.None;
        WeedManager.numberOfWeeds--; // ?
        if(parentGridArray != null)
        {
            parentGridArray.gridTaken[gridIndex] = false;
        }
        GameObject.Destroy(gameObject, 3f); //works
    }
}
