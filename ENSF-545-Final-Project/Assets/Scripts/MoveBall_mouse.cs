using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class MoveBall_mouse : MonoBehaviour
{
    private Vector3 savedPointerValue;

    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null)
        {
            Debug.Log("Null Mouse");
            return;
        }

        if(mouse.leftButton.wasPressedThisFrame)
        {
            // Save position for force calculation
            this.savedPointerValue = ConvertToWorldPoint((mouse.position.ReadValue()));
        }

        if(mouse.leftButton.wasReleasedThisFrame)
        {
           gameObject.SendMessage("ChangeDirection", CalculateForceVector());
        }

    }

    Vector2 CalculateForceVector()
    {
        if(Mouse.current == null)
        {
            Debug.Log("Null Mouse");
            return new Vector2(0.0f, 0.0f);
        }
        Vector3 currentMouseVec3 = ConvertToWorldPoint(Mouse.current.position.ReadValue());
        return new Vector2(currentMouseVec3.x - this.savedPointerValue.x, currentMouseVec3.y - this.savedPointerValue.y);
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

    Vector3 ConvertToWorldPoint(Vector2 screenPoint)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, Camera.main.nearClipPlane));
    }
}
