using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	// Use this for initialization
    public Transform target;
    public float fDistanciax;
    public float fCostanteRotacion = 3125;

    private GameObject scene;
	void Start () {
        scene = GameObject.Find("ESCENARIO");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            fDistanciax = col.gameObject.transform.position.x - target.transform.position.x;
            col.gameObject.transform.position = new Vector3(
                col.gameObject.transform.position.x,
                target.transform.position.y,
                col.gameObject.transform.position.z);
            //col.gameObject.transform.position = target.transform.position;
            scene.transform.Rotate(new Vector3(0, 0, fDistanciax * fCostanteRotacion) * Time.deltaTime);
        }
    }
}
