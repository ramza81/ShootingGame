using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if ((h == 1 && isTouchRight) || (h == -1 && isTouchLeft))
        {
            h = 0;
        }

        float v = Input.GetAxisRaw("Vertical");

        if ((v == 1 && isTouchTop) || (v == -1 && isTouchBottom))
        {
            v = 0;
        }

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
           animator.SetInteger("Input", (int)h);
        }

        // if (Input.GetButtonDown("Vertical") || Input.GetButtonUp("Vertical"))
        // {
        //    animator.SetInteger("Input", (int)v);
        // }        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Border")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;

                case "Bottom":
                    isTouchBottom = true;
                    break;

                case "Right":
                    isTouchRight = true;
                    break;

                case "Left":
                    isTouchLeft = true;
                    break;                                        
                
                default:
                    break;
            }
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;

                case "Bottom":
                    isTouchBottom = false;
                    break;

                case "Right":
                    isTouchRight = false;
                    break;

                case "Left":
                    isTouchLeft = false;
                    break;                                        
                
                default:
                    break;
            }
        }  
    }
}
