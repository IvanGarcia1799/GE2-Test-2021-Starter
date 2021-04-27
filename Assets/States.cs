using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WaitState : State
{
    public override void Enter ()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
    public override void Think(){
        if(GameObject.Find("Main Camera").GetComponent<Shooter>().returned == false){
            owner.ChangeState(new FetchState());
        }
    }

    public override void Exit() {
        owner.GetComponent<Seek>().enabled = true;
    }
}
class FetchState : State
{
    public override void Enter ()
    {
        owner.GetComponent<Seek>().targetGameObject = GameObject.Find("Main Camera").GetComponent<Shooter>().targetBall;
        owner.GetComponent<Arrive>().targetGameObject = GameObject.Find("Main Camera").GetComponent<Shooter>().targetBall;
        owner.GetComponent<Seek>().enabled = true;
    }
    public override void Think(){
        if(Vector3.Distance(owner.GetComponent<Seek>().targetGameObject.transform.position,
        owner.transform.position) <= 1){
            owner.GetComponent<Seek>().targetGameObject.transform.SetParent(owner.GetComponent<DogController>().mouth.transform);
            owner.ChangeState(new ReturnState());
        }
    }

    public override void Exit() {
        owner.GetComponent<Seek>().enabled = false;
    }
}

class ReturnState : State
{
    public override void Enter ()
    {
        owner.GetComponent<Seek>().targetGameObject = owner.GetComponent<DogController>().person;
        owner.GetComponent<Arrive>().targetGameObject = owner.GetComponent<DogController>().person;
        owner.GetComponent<Seek>().enabled = true;
    }
    public override void Think(){
        if (Vector3.Distance(owner.GetComponent<Seek>().targetGameObject.transform.position,
        owner.transform.position) <= 10){
            GameObject.Find("Main Camera").GetComponent<Shooter>().targetBall.transform.SetParent(null);
            owner.GetComponent<Seek>().targetGameObject = owner.transform.gameObject;
            owner.GetComponent<Arrive>().targetGameObject = owner.transform.gameObject;
            owner.ChangeState(new WaitState());
        }
    }

    public override void Exit() {
        owner.GetComponent<Seek>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Shooter>().returned = true;
    }
}
