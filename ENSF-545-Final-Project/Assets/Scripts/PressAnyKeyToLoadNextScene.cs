using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PressAnyKeyToLoadNextScene : MonoBehaviour
{
    // Detects if any key has been pressed.
    public int nextSceneToLoad;
    void Update()
    {
        if(Keyboard.current == null) return;
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}

