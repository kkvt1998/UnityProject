using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballPos;
    public Transform target;
    public Rigidbody rb;
    public TextMeshProUGUI textForce;
    public LineRenderer lr;

    private float startTime = 0f;
    private float timeHold = 0f;
    private float forceThrow;
    private int numPoints = 50;
    private Vector3 direction;
    private float timeStep = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textForce.text = "FORCE: " + forceThrow;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = numPoints;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        direction = target.position - ballPos.position;
        direction = direction.normalized;

        direction.y = direction.y + 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            startTime = Time.time;
        }
        if (Input.GetMouseButton(0))
        {
            timeHold = Time.time - startTime;
            forceThrow = (timeHold * 2f);
            textForce.text = "FORCE: " + Mathf.Round(forceThrow);
            DrawTrajectory(forceThrow);

        }
        if (Input.GetMouseButtonUp(0)) 
        {
            lr.positionCount = 0;
            Throw(forceThrow);
        }
    }
     void FixedUpdate()
    {
        
    }
    void DrawTrajectory(float force)
    {
        Vector3 velocity = direction * force;
        lr.positionCount = numPoints;

        for (int i = 0; i < numPoints; i++)
        {
            float t = i * timeStep;
            Vector3 point = ballPos.position + velocity * t + 0.5f * Physics.gravity * t * t;
            lr.SetPosition(i, point);
        }
    }
    void Throw(float Force)
    {
        rb.AddForce(direction * Force, ForceMode.Impulse);
    }
}
