using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ball;
    public GameObject targetBall;
    public float speed = 20.0f;

    public bool returned = true;
 
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
                targetBall = theBall;
                returned = false;
            }
        }
    }
}