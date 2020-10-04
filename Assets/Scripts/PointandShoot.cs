using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PointandShoot : MonoBehaviour
{
    public AudioSource myAudioSource;
    public GameObject CrossHair;
    public GameObject Player;
    public GameObject FireBallPrefab;
    public float FireBallSpeed;
    private Vector3 crosshair_point;
    private bool fire_Play = false;
    private bool fire_Playing = false;
    private float Timer = 0f;
    private void Start()
    {
        Cursor.visible = false;
       // myAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 1.8)
        {
            fire_Playing = false;
            Timer = 0f;
            myAudioSource.loop = false;
            myAudioSource.Stop();
        }
        if (fire_Play && !fire_Playing)
        {
            Timer = 0f;
            fire_Playing = true;            
            myAudioSource.loop = true;
            myAudioSource.Play();
            fire_Play = false;
        }
        crosshair_point = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        CrossHair.transform.position = new Vector2(crosshair_point.x, crosshair_point.y);

        Vector3 difference = crosshair_point - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        //Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            fire_Play = true;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireProjectile(direction, rotationZ);
        }
    }

    void fireProjectile(Vector2 direction,float rotationZ)
    {
        GameObject FireBall = Instantiate(FireBallPrefab) as GameObject;
        FireBall.transform.position = Player.transform.position;
        FireBall.transform.rotation = Quaternion.Euler(0.0f, 0.0f,rotationZ);
        FireBall.transform.rotation *= Quaternion.Euler(0, 0, 90);
        FireBall.GetComponent<Rigidbody2D>().velocity = direction * FireBallSpeed;
    }
}

