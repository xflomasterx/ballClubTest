using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private static int score = 0;
    public Text scoreText;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString("D3");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "ball")
        {
            Debug.Log("Won");
            score++;
        }
    }
}
