using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelScript : MonoBehaviour
{
    public Transform centerEyeAnchor;
    public float waitTime;
    private Vector3 wheelPos;
    public float heightOffset;
    public float speed;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject moon;
    public GameObject planet;
    private bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToOrient(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        /* Set Position of Wheel, Canvases, and Planets + Planet Rotation */

        if (gameObject.transform.position.y <= wheelPos.y)
        {
            gameObject.transform.position += transform.up * Time.deltaTime * speed;
        }
        if (winCanvas.transform.position.y <= wheelPos.y)
        {
            winCanvas.transform.position += transform.up * Time.deltaTime * speed;
        }
        if (loseCanvas.transform.position.y <= wheelPos.y)
        {
            loseCanvas.transform.position += transform.up * Time.deltaTime * speed;
        }

        if (moon.transform.position.y <= wheelPos.y)
        {
            moon.transform.position += transform.up * Time.deltaTime * speed;
        }

        if (planet.transform.position.y <= wheelPos.y)
        {
            planet.transform.position += transform.up * Time.deltaTime * speed;
        }
    }

    IEnumerator waitToOrient(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        wheelPos = new Vector3(gameObject.transform.position.x, centerEyeAnchor.position.y / heightOffset, gameObject.transform.position.z);

    }
}
