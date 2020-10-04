using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{   public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;

    private int n = 0;

    public Text WinText;
    public Text Restart;
    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(1, 5);
        if (n != 0)
        {
            if (n == 1)
            {
                transform.position = Spawn1.transform.position;
            }

            if (n == 2)
            {
                transform.position = Spawn2.transform.position;
            }

            if (n == 3)
            {
                transform.position = Spawn3.transform.position;
            }

            if (n == 4)
            {
                transform.position = Spawn4.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Time.timeScale = 0;
            WinText.enabled = true;
            Restart.enabled = true;
            WinText.text = "Winner";
        }
    }
}
