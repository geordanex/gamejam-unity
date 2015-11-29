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
    public bool introCompleted = false;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isRun;
    private bool isGrounded;
    private bool boPuedeBlinkearX;
    private bool boPuedeBlinkearY;
    private int lastYBlink;
    private bool keyPassBlink;
    private float fDistanciaX;
    float distanciaRecorrido = 50;
    private string dire;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        isRun = false;
        speed = 20;
        isGrounded = false;
        dire = "left";
        boPuedeBlinkearX = false;
        boPuedeBlinkearY = false;
        keyPassBlink = true;
        lastYBlink = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (!introCompleted) return;

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
        if (Input.GetKey(KeyCode.A) && (boPuedeBlinkearX || boPuedeBlinkearY))
        {
            Debug.Log("A precionada");
            ChangeState(STATE_BLINKENTER);
            keyPassBlink = true;
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
            rb.AddForce(new Vector2(0f, 50f),ForceMode2D.Force);
            isGrounded = false;
           
        }
        if(Input.GetKey(KeyCode.S))
        {
            ChangeState(STATE_DRILL);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("BlinkEnter"))
        {
            ChangeState(STATE_BLINKEXIT);
            if (boPuedeBlinkearX)
            {
                float direccion = -1;
                if (dire == "left") direccion = 1;
                scene.transform.Rotate(new Vector3(0f, 0f, distanciaRecorrido * direccion) * Time.deltaTime);
            }
            if(boPuedeBlinkearY)
            {
                if (lastYBlink == 1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f, transform.position.z);
                    
                }
                if (lastYBlink == -1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
                }
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BlinkExit"))
        {
            if (keyPassBlink)
            {
                lastYBlink *= -1;
                keyPassBlink = false;
            }
        }
       
        if ((Input.anyKey == false) && !isRun && animator.GetCurrentAnimatorStateInfo(0).IsName("Stop"))
        {
            ChangeState(STATE_IDLE);
        }
        Debug.Log("isgrounded" + isGrounded);

        Debug.Log(lastYBlink);
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("colisione");
        if(col.gameObject.tag == "Piso" && !isGrounded)
        {
            ChangeState(STATE_IDLE);
            isGrounded = true;
        }
        if(col.gameObject.tag == "Madera" && animator.GetCurrentAnimatorStateInfo(0).IsName("Drill"))
        {
            Destroy(col.gameObject);
        }
    }
    // Deteccion del blink
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "blinkOpX")
        {
            boPuedeBlinkearX = true;
            
        }
        if (coll.gameObject.tag == "blinkOpY")
        {
            boPuedeBlinkearY = true;

        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "blinkOpX")
        {
            boPuedeBlinkearX = false;
        }
        if (coll.gameObject.tag == "blinkOpY")
        {
            boPuedeBlinkearY = false;

        }
    }

    void ChangeDirection(string dir)
    {
        if(dir == "left")
        {
            transform.localScale = new Vector3(0.01320629f, 0.01320629f, 0.01320629f);
            dire = "left";
        }
        if (dir == "right")
        {
            transform.localScale = new Vector3(-0.01320629f, 0.01320629f, 0.01320629f);
            dire = "right";
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
