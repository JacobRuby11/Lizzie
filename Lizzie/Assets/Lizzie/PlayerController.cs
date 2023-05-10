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
    public LayerMask Solid;
    public float speedmult;
    float Ym;
    float Xm;
    public float Gravity;
    public int rayPrecision;
    RaycastHit[] hitInfo;
    bool Grounded;
    Vector3 HeadMomentum;

    void Awake() {
        controls = new Lizzie();
        Grounded = false;
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
        hitInfo = new RaycastHit[rayPrecision];
    }

    // Update is called once per frame
    void Update()
    {

        Xm += move.x * Time.deltaTime;
        Ym += move.y* 10 * Time.deltaTime;
        Ym -= Gravity * Time.deltaTime;
        HeadMomentum = new Vector3(Xm, Ym, 0);
        GroundCheck(Head);
        GroundCheck(Body1);
        GroundCheck(Body2);
        GroundCheck(Body3);
        GroundCheck(Body4);
        GroundCheck(Body5);
        
        Head.transform.Translate(HeadMomentum * speedmult * Time.deltaTime);
    }

    void GroundCheck(GameObject Part){
        
        float angle = 0; 
        for(int i=0; i<rayPrecision; i++){
            hitInfo[i] = new RaycastHit();
            float x = Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            angle += 2*Mathf.PI/rayPrecision;
            Vector3 Dir=new Vector3(Part.transform.position.x+x,Part.transform.position.y+y,0);
            // Double check raycast magnitude for body parts
            if(Physics.Raycast(Part.transform.position, new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0),out hitInfo[i],gameObject.transform.localScale.x * 0.6f, Solid)){
                Debug.Log(hitInfo[i].collider.name);
                Debug.DrawRay(Part.transform.position, new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0), Color.blue);
                HeadMomentum += new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0) * -1;
            }
        }
        



    }

}
