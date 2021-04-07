using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Specialized;

public class goalHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private static int score = 0;
    public Text scoreText;
    public float respawnDelay;
    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
    void Start()
    {
        score = 0;
        reinitBrick(true);
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
            reinitBrick(false);
        }
    }

    private void reinitBrick(bool respawnDelayOverwite)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
        this.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
        StartCoroutine(ExecuteAfterTime((respawnDelayOverwite ? 0f : respawnDelay), () =>
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponents<BoxCollider>()[0].enabled = true;
            this.gameObject.GetComponents<BoxCollider>()[1].enabled = true;
            this.gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-5.4f, 5.4f), UnityEngine.Random.Range(-2.0f, 10.0f), -1f);
        }));

    }

}
