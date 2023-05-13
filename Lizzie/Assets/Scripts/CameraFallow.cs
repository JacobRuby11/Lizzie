using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFallow : MonoBehaviour
{
    public GameObject Lizzie;
    public float fallowspeed;
    private Vector3 offset;
    public bool joined;
    Vector3 targetPos;

    void Start(){
        joined = false;
    }
  

    void Update()
    {
        if(joined){
            targetPos = Lizzie.transform.TransformPoint(Lizzie.transform.localPosition);
            offset = transform.position - targetPos;
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, fallowspeed * Time.deltaTime);
            transform.LookAt(Lizzie.transform);
            Debug.Log(targetPos);
        }
    }

}