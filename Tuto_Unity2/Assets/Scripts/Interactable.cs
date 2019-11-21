﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact(){
        //this method is meant to be overwritten
        //each type of interactable objects (items, ennemies) we'll have an interat method
        Debug.Log("Interacting with " + transform.name);
    }

    void Update(){
        if(isFocus && !hasInteracted){
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius){
                Interact();
                hasInteracted = true;
            }
        }

    }

    public void OnFocused (Transform playerTransform){
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDeFocused(){
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}