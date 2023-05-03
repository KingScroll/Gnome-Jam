using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeedManager : MonoBehaviour
{

    public static int numberOfWeeds;
    
    public GridArray[] spawnSides;
    public GameObject[] weedPrefab;

    public RootControl[] roots;

    float spawnTimer;

    public int weedThreshold = 7;
    public float rootGrowingSpeed;
    public float rootDistanceLeft;
    float rootGrowMultiplier;
    public float rootGrowRate = 2.5f;
    public float rootDecayRate = -1.75f;

    float timeElasped;
    public float spawnTimerReset;

    bool winGame;
    bool gameStarted;

    public GameObject winCanvasParent;
    public GameObject winCanvas1, winCanvas2;
    public GameObject loseCanvas;
    public GameObject winParticles1, winParticles2;
    public AudioSource audioSource;
    public AudioClip victoryMusic;
    public GameObject reloadWeed;
    public GameObject reloadCanvas;

    private void Start()
    {
        spawnSides = GetComponentsInChildren<GridArray>();
        spawnTimer = 2;
    }

    private void Update()
    {
        if (gameStarted)
        {
            if (spawnTimer < 0 && !winGame)
            {
                SpawnWeed();
                SpawnWeed();
                spawnTimer = spawnTimerReset;
            }

            if (timeElasped > 10 && spawnTimerReset > 4)
            {
                spawnTimerReset -= 0.5f;
                timeElasped = 0;
            }
            timeElasped += Time.deltaTime;

            spawnTimer -= Time.deltaTime;

            foreach (RootControl root in roots)
            {
                root.UpdateFillValue(rootDistanceLeft);
            }

            rootGrowingSpeed = 0.1f * Time.deltaTime;

            if (numberOfWeeds > weedThreshold)
            {
                rootGrowMultiplier = rootDecayRate;
            }
            else if (numberOfWeeds < weedThreshold)
            {
                rootGrowMultiplier = rootGrowRate;
            }

            rootDistanceLeft -= rootGrowingSpeed / 60 * rootGrowMultiplier;

            if(rootDistanceLeft >= 0.99f)
            {
                //lose game
                var weeds = GameObject.FindGameObjectsWithTag("weed");
                foreach(var i in weeds)
                {
                    Destroy(i);
                }
                loseCanvas.SetActive(true);
                reloadCanvas.SetActive(true);
                reloadWeed.SetActive(true);
            }

            if (rootDistanceLeft <= 0 && !winGame)
            {
                //win the game
                //earth is our gnome
                var weeds = GameObject.FindGameObjectsWithTag("weed");
                foreach (var i in weeds)
                {
                    Destroy(i);
                }
                audioSource.clip = victoryMusic;
                audioSource.Play();
                winCanvasParent.SetActive(true);
                //winCanvas1.SetActive(true);
                //winCanvas2.SetActive(true);
                winParticles1.SetActive(true);
                winParticles2.SetActive(true);
                reloadWeed.SetActive(true);
                reloadCanvas.SetActive(true);
                GnomeControl.ActivateAnimationBool("Happy");
                winGame = true;
            }
        }
    }

    void SpawnWeed()
    {
        int chosenSide = Random.Range(0, spawnSides.Length);

        Transform spawnLocation = spawnSides[chosenSide].GetUnoccupiedLocation();

        if(spawnLocation != null)
        {
            GameObject newWeed = Instantiate(weedPrefab[Random.Range(0, weedPrefab.Length)], spawnLocation);
            newWeed.transform.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            newWeed.transform.localEulerAngles = new Vector3(Random.Range(-30f, 30f), Random.Range(0f, 360f), Random.Range(-30f, 30f));
            newWeed.GetComponent<GrabWeeds>().spawnPoint = spawnLocation;
            numberOfWeeds++;
        }
    }

    public void StartSpawning()
    {
        gameStarted = true;
    }

    public void ResetGame()
    {
        numberOfWeeds = 0;
        SceneManager.LoadScene(0);
    }
}
