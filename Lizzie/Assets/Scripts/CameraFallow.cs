using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFallow : MonoBehaviour
{
    public GameObject Lizzie;
    public float fallowspeed = 3f;
    private Vector3 offset;
    public bool joined = false;
  

    void Update()
    {
        if(joined){
            offset = transform.position - Lizzie.transform.position;
            transform.position = Vector3.Lerp(transform.position, Lizzie.transform.position + offset, fallowspeed * Time.deltaTime);
            transform.LookAt(Lizzie.transform);
        }
    }

}