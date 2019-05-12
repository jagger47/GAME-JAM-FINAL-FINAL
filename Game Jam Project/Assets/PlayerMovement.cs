using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Vector3> v = new List<Vector3>();
    public float carSpeed = 1000000;
    private float time = 180f;
    private int indx;
    private int direction = 0;
    private bool walking = false;

    private Animator animator;

    void Start()
    {
        indx = 0;
        transform.position = v[indx];
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        checkTime();
    }

    void checkTime()
    {
        time -= Time.deltaTime;
        if ( time <= 0 )
        {
            if ( indx < 3 )
            {
                indx++;
            } else
            {
                indx = 0;
            }

            transform.position = v[indx];
            time = 180;
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey("left"))
        {
            transform.position -= new Vector3(carSpeed * Time.deltaTime, 0, 0);
            direction = 2;
            walking = true;

        }
        else if (Input.GetKey("right"))
        {
            transform.position += new Vector3(carSpeed * Time.deltaTime, 0, 0);
            direction = 1;
            walking = true;
        }
        else if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, carSpeed * Time.deltaTime, 0);
            direction = 0;
            walking = true;
        }
        else if (Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, carSpeed * Time.deltaTime, 0);
            direction = 3;
            walking = true;
        }
        else
        {
            walking = false;
        }

        animator.SetInteger("direction", direction);
        animator.SetBool("walking", walking);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 currentPos = transform.position;
        if (col.gameObject.name == "Tilemap")
        {
            transform.position -= (transform.position - currentPos);
        }
    }
}