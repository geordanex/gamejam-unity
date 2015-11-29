using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	// Use this for initialization
    public Transform target;
    public float fDistanciax;

    private GameObject scene;
	void Start () {
        scene = GameObject.Find("ESCENARIO");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        col.gameObject.transform.position = target.transform.position;

        fDistanciax = col.gameObject.transform.position.x - col.gameObject.transform.position.x;
        scene.transform.Rotate(new Vector3(0, fDistanciax , 0) * Time.deltaTime);
    }
}
