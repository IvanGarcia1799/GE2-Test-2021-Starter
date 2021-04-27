using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    public GameObject person;
    public GameObject mouth;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new ReturnState());
    }
    // Update is called once per frame
}
