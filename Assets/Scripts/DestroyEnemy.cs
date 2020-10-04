using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    EnemyHealth enemyhealth;
    private bool hit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Enemy")
        {
            hit = true;
            enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void OnDestroy()
    {
        if (hit)
        {
            enemyhealth.RemoveHealthPoint(1);
        }
        
    }
}
