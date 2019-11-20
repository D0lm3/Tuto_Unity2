﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, movementMask)){

               motor.MoveToPoint(hit.point);
                //move our player to what we hit

                RemoveFocus(); //stop focusing object

            }
        }
         if(Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100)){

             Interactable interactable =  hit.collider.GetComponent<Interactable>();//check if we hit an interactable
               if(interactable != null){
                   SetFocus(interactable);//if we did set as our focus
            }
        }
    }

    void SetFocus (Interactable newFocus){
         focus = newFocus;
         motor.FollowTarget(newFocus);
    }

    void RemoveFocus(){
        focus = null;
        motor.StopFollowingTarget();
    }
}
}
