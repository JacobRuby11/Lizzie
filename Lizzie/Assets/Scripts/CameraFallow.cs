using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFallow : MonoBehaviour
{
    public GameObject Lizzie;
    public float fallowspeed;
    public Vector3 offset;
    public bool joined;
    Vector3 targetPos;


    void Start(){
        joined = false;
    }
  

    void Update()
    {
        if(joined){
            targetPos = Lizzie.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, fallowspeed * Time.deltaTime);
            transform.LookAt(Lizzie.transform);
            
        }
    }

}