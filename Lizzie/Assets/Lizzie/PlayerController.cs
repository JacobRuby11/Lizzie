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
                HeadMomentum += new Vector3(Dir.x-Part.transform.position.x,Dir.y-Part.transform.position.y,0) * -1;
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

}
