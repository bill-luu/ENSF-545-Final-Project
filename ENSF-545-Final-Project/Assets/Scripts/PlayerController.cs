using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectsWithTag("pickup").Length;
        SetCountText();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            score--;
            SetCountText();
            if(score == 0) {
                SceneManager.LoadScene(2);
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Remaining Coins: " + score;
    }
}
