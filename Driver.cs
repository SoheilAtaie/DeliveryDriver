using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float steerSpeed = 1000f;
    [SerializeField]
    float moveSpeed = 20f;
    float slowSpeed = 15f;
    float boostSpeed = 30f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -(steerAmount));
            transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Booster")
        {
            Debug.Log("You are boosting!");
            moveSpeed = boostSpeed;
        }
        else if (collision.tag == "Bumper")
        {
            Debug.Log("You are slowed down!");
            moveSpeed = slowSpeed;
        }
    }


}
