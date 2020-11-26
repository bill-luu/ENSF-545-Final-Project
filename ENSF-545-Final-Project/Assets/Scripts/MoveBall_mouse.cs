using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System;


public class MoveBall_mouse : MonoBehaviour
{
    private Vector3 savedPointerValue;
    private bool processingFlick = false;

    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null)
        {
            Debug.Log("Null Mouse");
            return;
        }

        if(mouse.leftButton.wasPressedThisFrame && this.ClickedOnObject())
        {
            // Save position for force calculation
            this.savedPointerValue = mouse.position.ReadValue();
            this.processingFlick = true;
        }

        if(mouse.leftButton.wasReleasedThisFrame && this.processingFlick)
        {
           gameObject.SendMessage("ChangeDirection", CalculateForceVector());
           this.processingFlick = false;
        }

    }

    Vector2 CalculateForceVector()
    {
        if(Mouse.current == null)
        {
            Debug.Log("Null Mouse");
            return new Vector2(0.0f, 0.0f);
        }
        float x = (Mouse.current.position.ReadValue().x - this.savedPointerValue.x) / Screen.width;
        float y = (Mouse.current.position.ReadValue().y - this.savedPointerValue.y) / Screen.height;
        return new Vector2(x, y);
    }

    bool ClickedOnObject()
    {
        if(Mouse.current == null)
        {
            Debug.Log("Null Mouse");
            return false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.name == gameObject.name)
                return true;
        }

        return false;
    }
}
