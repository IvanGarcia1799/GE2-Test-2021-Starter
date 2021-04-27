using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    public GameObject person;
    public GameObject mouth;
    public gameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ball = GetComponent<Shooter>().thrownBall;
    }
}
