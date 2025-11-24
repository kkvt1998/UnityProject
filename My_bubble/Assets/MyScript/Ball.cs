using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isClicked = false;
    public Renderer rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickBall()
    {
        if (!isClicked) 
        {
            rd.material.color = Color.white;
            Destroy(gameObject, 1f);
            isClicked = true;
        }

    }
}
