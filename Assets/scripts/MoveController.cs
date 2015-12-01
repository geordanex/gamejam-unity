using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	// Use this for initialization
    public bool canMoveLeft;
    public bool canMoveRight;
    public string dir;
    public GameObject notWalle;
    private NotWalleController nwc;
	void Start () {
        canMoveLeft = true;
        canMoveRight = true;
        nwc = notWalle.GetComponent<NotWalleController>();
        dir = nwc.dire;
	}
	
	// Update is called once per frame
	void Update () {
        dir = nwc.dire;
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Player")
        {
            Debug.Log(dir);
            if(dir == "left")
            canMoveLeft = false;
            if (dir == "right")
                canMoveRight = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
            
                canMoveLeft = true;
           
                canMoveRight = true;
    }
}
