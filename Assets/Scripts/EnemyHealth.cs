using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthpoints = 1;
   
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (healthpoints == 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    public void RemoveHealthPoint(int dmg)
    {
        healthpoints -= dmg;
        if (healthpoints < 0)
        {
            healthpoints = 0;
        }
    }
}
