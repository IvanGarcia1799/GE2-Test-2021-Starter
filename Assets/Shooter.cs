using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ball;
    public GameObject thrownBall;
    public float speed = 7.0f;
 
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject theBall = (GameObject)Instantiate(ball, mouseRay.origin, Quaternion.identity);
            Rigidbody rb = theBall.GetComponent<Rigidbody>();
 
            if (rb != null)
            {
                rb.velocity = mouseRay.direction * speed;
            }
        }
    }
}