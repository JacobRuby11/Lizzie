using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController headController;
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
    public float maxStretch;
    public float spring;
    public float friction;
    int strength;
    float Ym;
    float Xm;
    public float Gravity;
    public int rayPrecision;
    RaycastHit[] hitInfo;
    bool Grounded;
    Vector3 HeadMomentum;
    Part head;
    Part body1;
    Part body2;
    Part body3;
    Part body4;
    Part body5;

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
        head = new Part(Head, true);
        body1 = new Part(Body1, false);
        body2 = new Part(Body2, false);
        body3 = new Part(Body3, false);
        body4 = new Part(Body4, false);
        body5 = new Part(Body5, false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(head.momentum.y);
        
        GroundCheck(ref head);
        GroundCheck(ref body1);
        GroundCheck(ref body2); 
        GroundCheck(ref body3); 
        GroundCheck(ref body4); 
        GroundCheck(ref body5);

        check_touching();
        
        head.momentum.x += move.x * speedmult* Time.deltaTime;
        if(head.grounded)
        {
            head.momentum.y += move.y * 10 * Time.deltaTime;
        }
        else
        {
            head.momentum.y -= Gravity * (strength/6) * Time.deltaTime;
            if (strength < 6) { head.momentum.y += move.y * 4 * Time.deltaTime; }
        }
       
        FollowObject(head, ref body1);
        FollowObject(body1, ref body2);
        FollowObject(body2, ref body3);
        FollowObject(body3, ref body4);
        FollowObject(body4, ref body5);

        
        headController.Move(head.momentum * Time.deltaTime);
    }

    void GroundCheck(ref Part p){
        //starting angle
        float angle = 0;
        // Loop by ray precision to cast rays around part
        p.grounded = false;
        for(int i=0; i<rayPrecision; i++){
            
            /****************** Math for Raycast *******************/
            // Store individual hit info
            hitInfo[i] = new RaycastHit();
            // X coordinate of new angle
            float x = Mathf.Sin(angle);
            // Y coordinate of new angle.
            float y = Mathf.Cos(angle);
            // Add to angle to get next angle
            angle += 2*Mathf.PI/rayPrecision;
            // Get vector from x and y coordinates based off of part's position
            Vector3 Dir=new Vector3(p.obj.transform.position.x+x,p.obj.transform.position.y+y,0);
            /********************************************************/


            // // // // TODO: Double check raycast magnitude for body parts, 0.6f scale barely peek out of head
            if (Physics.Raycast(p.obj.transform.position, new Vector3(Dir.x-p.obj.transform.position.x,Dir.y-p.obj.transform.position.y,0),out hitInfo[i],gameObject.transform.localScale.x * 0.6f, Solid)){
                p.grounded = true;
                // Keeps us above the surface without effecting momentum
                p.momentum += new Vector3(0, Dir.y - p.obj.transform.position.y, 0) *-1;

                // calc slope
                float slope = Vector3.Angle(Vector3.up, hitInfo[i].normal);

                if(slope > 60){
                    if(Mathf.Abs(move.x) < 0.1f){
                        p.momentum.x = 0;
                    }
                }
                if (Mathf.Abs(move.y) < 0.1f)
                {
                    p.momentum.y = 0;
                }
               
            }
        }

        p.momentum.x *= Mathf.Pow(friction, Time.deltaTime);

    }

    void FollowObject(Part toFollow, ref Part p){
    
        Vector3 dir = toFollow.obj.transform.position - p.obj.transform.position;
        float distance = Vector3.Distance(toFollow.obj.transform.position, p.obj.transform.position);
        dir = dir.normalized * distance/10f;
       
        if(p.grounded){
            p.yVel = 0;
        }
        else{
            p.yVel -= (Gravity * Time.deltaTime);
        }
        
        
        if(distance > 0.5){
            // FOllOW
            dir += p.yVel * Vector3.up * Time.deltaTime;
            p.momentum.y += dir.y * 0.5f;
            p.momentum.x += dir.x * 0.5f;
        }
        else
        {
            // ONLY GRAVITY
            
            dir.x = 0;
            dir.y = 0;
            dir += p.yVel * Vector3.up * Time.deltaTime;
        }

        p.obj.transform.Translate(dir);

    }

    void check_touching()
    {
        strength = 0;

        if (!head.grounded) {
            strength += 1;
        }
        if (!body1.grounded)
        {
            strength += 1;
        }
        if (!body2.grounded)
        {
            strength += 1;
        }
        if(!body3.grounded){
            strength +=1;
        }
        if (!body4.grounded)
        {
            strength += 1;
        }
        if (!body5.grounded)
        {
            strength += 1;
        }
        Debug.Log(strength);

    }


}

struct Part{
    public GameObject obj;
    public Vector3 momentum;
    public bool grounded;
    public bool isHead;
    public float yVel;
    public Part(GameObject g, bool ishead){
        obj = g;
        momentum = new Vector3();
        grounded = false;
        yVel = 0;
        isHead = ishead;
    }
}
