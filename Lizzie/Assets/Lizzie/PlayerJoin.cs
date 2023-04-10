using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    public Camera cam;
    PlayerInputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    void OnPlayerJoined(PlayerInput playerInput){
        Debug.Log("HI");
        cam.GetComponent<CameraFallow>().Lizzie = playerInput.gameObject;
        cam.GetComponent<CameraFallow>().joined = true;
    }
}
