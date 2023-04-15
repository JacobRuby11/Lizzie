using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 move;
    Lizzie controls;
    public GameObject Head;
    public GameObject Body1;
    public GameObject Body2;
    public GameObject Body3;
    public GameObject Body4;
    public GameObject Body5;

    public float speedmult;
    float Ym;
    float Xm;
    public float Gravity;


    void Awake() {
        controls = new Lizzie();
    }

    public void OnMove(InputAction.CallbackContext context){
        move = context.ReadValue<Vector2>();
    }
    private void OnEnable() {
        controls.Player.Enable();
        
    }
    private void OnDisable() {
        controls.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Xm += move.x * Time.deltaTime;
        Ym += move.y * Time.deltaTime;
        Ym -= Gravity * Time.deltaTime;
        Head.transform.Translate(new Vector3(Xm, Ym, 0) * speedmult * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other) {
        
    }

}
