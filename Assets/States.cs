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

    }

    public override void Exit() {

    }
}
class FetchState : State
{
    public override void Enter ()
    {
        owner.GetComponent<Seek>().targetGameObject = GameObject.Find("Main Camera").GetComponent<Shooter>().targetBall;
        owner.GetComponent<Seek>().enabled = true;
    }
    public override void Think(){
                if(Vector3.Distance(owner.GetComponent<Seek>().targetGameObject.transform.position,
        owner.tranform.position) <= 1){
            owner.GetComponent<Seek>().targetGameObject.parent = owner.GetComponent<DogController>().mouth;
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
        owner.GetComponent<Seek>().enabled = true;
    }
    public override void Think(){
        if (Vector3.Distance(owner.GetComponent<Seek>().targetGameObject.transform.position,
        owner.transform.position) <= 10){
            owner.GetComponent<DogController>().ball.parent = null;
            owner.ChangeState(new WaitState());
        }
    }

    public override void Exit() {
        owner.GetComponent<Seek>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Shooter>().returned = true;
    }
}
