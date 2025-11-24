using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public GameObject Hoop;
    private bool scored = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Vao ro");
            score++;
        }
        if (other.name == "Ball" && !scored)
        {
            scored = true;
        }

    }
}
