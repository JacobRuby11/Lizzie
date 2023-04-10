using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float spring;
    public GameObject toFollow;
    public float maxStretch;
    public float momentum;
    float strength;
    float distance;
    float MyDirection;
    float TargetX;
    float TargetY;
    // Start is called before the first frame update
    void Start()
    {
        maxStretch = 1;
        strength = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, toFollow.transform.position);
        if(distance > maxStretch ){
            FollowObject();
        }
    }

    public void FollowObject(){
        if(gameObject.transform.position.y>toFollow.transform.position.y){
        MyDirection = (Mathf.Atan((gameObject.transform.position.x-toFollow.transform.position.x)/(gameObject.transform.position.y-toFollow.transform.position.y)))+(Mathf.Deg2Rad * 180);
        
        Debug.Log ("move180");
        }
        else{
        MyDirection = Mathf.Atan((gameObject.transform.position.x-toFollow.transform.position.x)/(gameObject.transform.position.y-toFollow.transform.position.y));
        }
        TargetX = toFollow.transform.position.x - maxStretch*Mathf.Sin(MyDirection);
        TargetY = toFollow.transform.position.y - maxStretch*Mathf.Cos(MyDirection);
        transform.position += new Vector3((TargetX-gameObject.transform.position.x)/spring,((TargetY-gameObject.transform.position.y)/spring),0);
        
        //transform.LookAt(toFollow.transform, Vector3.up);
        //transform.Translate(transform.forward * strength * (distance-maxStretch));
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
}