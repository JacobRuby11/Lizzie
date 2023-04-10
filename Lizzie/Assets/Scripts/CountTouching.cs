using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTouching : MonoBehaviour
{
    //GameObject
   // var collisionObject = GameObject;
    public float strength = 0;
    public float touchingchecks = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if collision cube;
        touchingchecks += 1;
       // MonoBehavior.OnCollisionStay();
    }
}