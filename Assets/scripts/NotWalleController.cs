using UnityEngine;
using System.Collections;

public class NotWalleController : MonoBehaviour {

    const int STATE_IDLE = 0;
    const int STATE_RUN = 1;
    const int STATE_STOP = 2;
    const int STATE_BLINKENTER = 3;
    const int STATE_BLINKEXIT = 4;
    const int STATE_JUMP = 5;
    const int STATE_DRILL = 6;

    public Transform scene;
    public float speed;

    private Animator animator;
    private Rigidbody rb;
    private bool isRun;
    private bool isGrounded;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        isRun = false;
        speed = 20;
        isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.LeftArrow))
        {
            scene.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
            ChangeDirection("left");
            ChangeState(STATE_RUN);
            isRun = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            scene.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime * -1f);
            ChangeDirection("right");
            ChangeState(STATE_RUN);
            isRun = true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            ChangeState(STATE_BLINKENTER);
        }
        if((Input.anyKey == false) && isRun)
        {
            Debug.Log("stop");
            ChangeState(STATE_STOP);
            isRun = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ChangeState(STATE_JUMP);
            rb.AddForce(new Vector3(0f, 20f, 0f),ForceMode.Impulse);
            isGrounded = false;
           
        }
        if(Input.GetKey(KeyCode.S))
        {
            ChangeState(STATE_DRILL);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("BlinkEnter"))
        {
            ChangeState(STATE_BLINKEXIT);
        }
       
        if ((Input.anyKey == false) && !isRun && animator.GetCurrentAnimatorStateInfo(0).IsName("Stop"))
        {
            ChangeState(STATE_IDLE);
        }
        Debug.Log(isGrounded);
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("colisione");
        if(col.gameObject.tag == "Piso" && !isGrounded)
        {
            ChangeState(STATE_IDLE);
            isGrounded = true;
        }
    }

    void ChangeDirection(string dir)
    {
        if(dir == "left")
        {
            transform.localScale = new Vector3(0.01320629f, 0.01320629f, 0.01320629f);
        }
        if (dir == "right")
        {
            transform.localScale = new Vector3(-0.01320629f, 0.01320629f, 0.01320629f);
        }
    }

    void ChangeState(int state)
    {
        switch(state)
        {
            case STATE_IDLE:
                animator.SetInteger("State", STATE_IDLE);
                break;
            case STATE_RUN:
                animator.SetInteger("State", STATE_RUN);
                break;
            case STATE_STOP:
                animator.SetInteger("State", STATE_STOP);
                break;
            case STATE_BLINKENTER:
                animator.SetInteger("State", STATE_BLINKENTER);
                break;
            case STATE_BLINKEXIT:
                animator.SetInteger("State", STATE_BLINKEXIT);
                break;
            case STATE_JUMP:
                animator.SetInteger("State", STATE_JUMP);
                break;
            case STATE_DRILL:
                animator.SetInteger("State", STATE_DRILL);
                break;
        }
    }
}
