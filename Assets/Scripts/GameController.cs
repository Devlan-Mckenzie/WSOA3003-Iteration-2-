using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public SpawnEnemy spawner1;
    public SpawnEnemy spawner2;
    public SpawnEnemy spawner3;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Score.scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}