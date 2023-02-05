
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chill_charactercontroler : MonoBehaviour
{
    
    float side_movement;
    float forward_movement;
    float hrot,vrot;
    float ncamerarotation=0;
    public CharacterController cc;
    public float MS=2;
    float sens=2;
    public float interactionDistance = 3f;
    public bool imnear;
    public GameObject cam;

    private Camera camer;
    private Vector3 pos = new Vector3(200, 200, 0);

    private GameObject target;

    public GameManager_script GM;

    void Start() {
        cc=gameObject.GetComponent<CharacterController>();
   
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        camer = cam.GetComponent<Camera>();
    }

    void Update() {
        handle_inputs();
        handle_movement();
        handle_rotate();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MouseClick();
        }
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("Mouse0 key was released.");
        }*/

        RaycastHit rayhit;

        Debug.DrawRay(transform.position, transform.forward * interactionDistance);

        if (Physics.Raycast(transform.position, transform.forward, out rayhit, interactionDistance))
        {
            imnear = (rayhit.collider.tag == "Clickable");
            if (imnear) {
                target = rayhit.collider.gameObject;
            }
        }
    }


    void handle_movement(){
        if(GM.gameEnded == false) { 
        Vector3 movedir= transform.forward*(forward_movement*(1)) + transform.right*(side_movement*(1)) + transform.up*-1;
        cc.Move(MS*Time.deltaTime*movedir);
        }
    }

    void handle_inputs(){
        side_movement=Input.GetAxis("Horizontal");
        forward_movement=Input.GetAxis("Vertical");
    }

    void handle_rotate(){
        if (GM.gameEnded == false) {
            float hrot =Input.GetAxis("Mouse X");
            float vrot=Input.GetAxis("Mouse Y");
            transform.Rotate(0,hrot*sens,0);
            //cam.transform.Rotate(-vrot*sens,0,0);
            ncamerarotation-=vrot*sens;

            float minRotation = -95;
            float maxRotation = 95;
            ncamerarotation= Mathf.Clamp(ncamerarotation, minRotation, maxRotation);
            cam.transform.localRotation= Quaternion.Euler (ncamerarotation,0,0);

            


        }





    }

    void MouseClick()
    {
        if (imnear)
        {
            imnear = false;
            if (target.GetComponent<Feature_script>().IsParent)
            {
                Debug.Log(target.GetComponent<Feature_script>().IsParent);

                GM.ParentFound();
                Destroy(target);
            }else{
                Debug.Log("this person is not my parent");
                //limitet quesses so decrement some variable
            }

        }
    }

}

