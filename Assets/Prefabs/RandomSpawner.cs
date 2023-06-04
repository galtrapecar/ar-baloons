using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class RandomSpawner : MonoBehaviour
{
    private float wait  = 5.0f;
    private float timer = 0.0f;
    public GameObject redBaloonPrefab;
    public GameObject blueBaloonPrefab;
    public GameObject greenBaloonPrefab;
    public GameObject purpleBaloonPrefab;
    public GameObject yellowBaloonPrefab;

    public Camera camera;

    private GameObject[] pool;

    private int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        pool = new GameObject[] { redBaloonPrefab, blueBaloonPrefab, greenBaloonPrefab, purpleBaloonPrefab, yellowBaloonPrefab };
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wait)
        {
            Vector3 spawnPoint;
            while (true)
            {
                spawnPoint = new Vector3(Random.Range(-30, 31), Random.Range(1, 5), Random.Range(-30, 31));
                float dist = Vector3.Distance(spawnPoint, this.transform.position);

                if (dist > 3.0f) break;
            }
            
            Instantiate(pool[Random.Range(0, 6)], spawnPoint, Quaternion.identity);

            timer = timer - wait;
        }
    }
}
