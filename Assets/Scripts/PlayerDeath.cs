using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDeath : MonoBehaviour
{
    public Text GameOver;
    public Text Restart;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.enabled = false;
        Restart.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            GameOver.enabled = true;
            Restart.enabled = true;
            Time.timeScale = 0;
        }
        
    }
}
