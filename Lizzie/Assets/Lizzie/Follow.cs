using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    /**
    public float spring;
    public GameObject toFollow;
    public float maxStretch;
    public Vector3 momentum;
    public bool Grounded;
    public float friction;
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
        Grounded = false;
        friction = 0.3f;
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
        }
        else{
            MyDirection = Mathf.Atan((gameObject.transform.position.x-toFollow.transform.position.x)/(gameObject.transform.position.y-toFollow.transform.position.y));
        }
        TargetX = toFollow.transform.position.x - maxStretch*Mathf.Sin(MyDirection);
        TargetY = toFollow.transform.position.y - maxStretch*Mathf.Cos(MyDirection);

        momentum += new Vector3((TargetX-gameObject.transform.position.x)/spring,((TargetY-gameObject.transform.position.y)/spring),0) * Time.deltaTime;
        momentum *= Mathf.Pow(friction, Time.deltaTime);

        if(Grounded)

        transform.position += momentum *Time.deltaTime;
        
        //transform.LookAt(toFollow.transform, Vector3.up);
        //transform.Translate(transform.forward * strength * (distance-maxStretch));
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
    void GroundCheck(GameObject Part){
        //starting angle
        float angle = 0; 
        // Loop by ray precision to cast rays around part
        for(int i=0; i<rayPrecision; i++){
            // Store individual hit info
            hitInfo[i] = new RaycastHit();
            // X coordinate of new angle
            float x = Mathf.Sin(angle);
            // Y coordinate of new angle.
            float y = Mathf.Cos(angle);
            // Add to angle to get next angle
            angle += 2*Mathf.PI/rayPrecision;
            // Get vector from x and y coordinates based off of part's position
            Vector3 Dir=new Vector3(Part.transform.position.x+x,Part.transform.position.y+y,0);


            // // // // TODO: Double check raycast magnitude for body parts, 0.6f scale barely peek out of head
            if(Physics.Raycast(Part.transform.position, new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0),out hitInfo[i],gameObject.transform.localScale.x * 0.6f, Solid)){
                // Keeps us above the surface without effecting momentum
                momentum += new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0) * -1;
                // Calc slope of surface we are touching
                float slope = Vector3.Angle(Vector3.up, hitInfo[i].normal);
                // If slop is more than value, it will effect x and y momentum effect will change based off of y input
                if(slope > 60 ){
                    Xm *= -0.1f;
                    if(Mathf.Abs(move.y) <= 0.1f){
                        if (Ym < 0f) {Ym *= -0.5f;}
                    }
                }
                else{
                    if (Ym < 0f) {Ym *= -0.5f;}
                }      
            }
        }
    }
    **/
}
