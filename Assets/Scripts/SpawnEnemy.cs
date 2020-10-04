using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount;
    public int xPos, yPos, zPos;
    private bool spawn = false;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if (started == false && spawn == true)
        {            
            StartCoroutine(EnemySpawn());
            started = true;
        }
    }
    IEnumerator EnemySpawn()
    {
        while (enemyCount < 10)
        {
            Instantiate(enemy,new Vector3(xPos,yPos,zPos),Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 1;
        }
    }

    public void EnemyDied()
    {
        enemyCount -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spawn = true;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spawn = false;           
        }
    }
}
