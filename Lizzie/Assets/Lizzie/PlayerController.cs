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
    public LayerMask Stickable;
    public float speedmult;
    float Ym;
    float Xm;
    public float Gravity;
    public int rayPrecision;
    RaycastHit[] hitInfo;


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
        hitInfo = new RaycastHit[] {};
    }

    // Update is called once per frame
    void Update()
    {
        Xm += move.x * Time.deltaTime;
        Ym += move.y * Time.deltaTime;
        Ym -= Gravity * Time.deltaTime;
        GroundCheck(Head);
        GroundCheck(Body1);
        GroundCheck(Body2);
        GroundCheck(Body3);
        GroundCheck(Body4);
        GroundCheck(Body5);
        Head.transform.Translate(new Vector3(Xm, Ym, 0) * speedmult * Time.deltaTime);
    }

    void GroundCheck(GameObject Part){
        
        float angle = 0; 
        for(int i=0; i<rayPrecision; i++){
            float x = Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            angle += 2*Mathf.PI/rayPrecision;
            Vector3 Dir=new Vector3(Part.transform.position.x+x,Part.transform.position.y+y,0);
            Debug.DrawLine(Part.transform.position,Dir*10,Color.blue);

        }
        //Physics.Raycast(Head.transform.position,Vector3.up,out hitInfo[0],Stickable);



    }

}
