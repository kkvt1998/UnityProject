using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Buble : MonoBehaviour
{
    public GameObject ballPrefab;
   
    public Vector3 startPos;
    public Rigidbody rb;
    public Renderer rd;
    public TMP_Text textScore;
    public TMP_Text textTimer;
    public TMP_Text textResult;

    private int score = 0;
    private float timer = 60f;
    private bool isClicked = false;
    private int target;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InitBall",0f, 2f);
        target = Random.Range(5, 20);
        textScore.text = "SCORE: " + score + "/" + target;
    }

    // Update is called once per frame
    void Update()
    {
        ClickBall();
        timeCounter();
    }
    void InitBall()
    {
       
        GameObject ball = Instantiate(ballPrefab, startPos, Quaternion.identity);
        ball.name = ballPrefab.name + Time.time;
        rb = ball.GetComponent<Rigidbody>();

        //move Up
        float forceUp = Random.Range(1f, 2f);
        rb.AddForce(forceUp * Vector3.up, ForceMode.Impulse);

        //Auto Destroy after 10s
        Destroy(ball, 10f );
    }
    void ClickBall()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked ) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.enabled = false;
                hit.collider.GetComponent<Ball>().ClickBall();
                score++;
                textScore.text = "SCORE: " + score + "/" + target;
               
            }
        }
        
    }
    void timeCounter()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            timer = 0f;
            Time.timeScale = 0;

        }
        textTimer.text = "TIME: " + (int)timer;
        Result();
    }
    void Result()
    {
        
        if(timer == 0)
        {
            if(score >= target)
            {
                textResult.text = "Win";
            }
            else { textResult.text = "LOSE"; }
        }
    }
}
