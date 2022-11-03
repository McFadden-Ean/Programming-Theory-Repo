using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hMove;
    private float vMove;
    private float zBound = 5.0f;
    private float xBound = 10.0f;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
   
    // Update is called once per frame
    void Update()
    {
        Move();
        Pivot();
    }
    private void Move()
    {
        //moves the player
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            vMove = 1;
        }
        else
        {
            vMove = 0;
        }
        float shiftZ = vMove * speed * Time.deltaTime;
        transform.Translate(0, 0, shiftZ);
        Bounds();     
    }
    private void Pivot()
    {
        //rotates the player
        hMove = Input.GetAxis("Horizontal");
        float shiftY = hMove * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, shiftY, 0);
    }

    private void Bounds()
    {
        //restricts player movement
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
}
