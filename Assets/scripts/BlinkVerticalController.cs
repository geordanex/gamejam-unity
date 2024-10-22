using UnityEngine;
using System.Collections;

public class BlinkVerticalController : MonoBehaviour {
	
	public GameObject goDistancia;
	GameObject goPlayer;
	public bool boPuedeBlinkear = false;
	public float fDistanciay;
	
	// Use this for initialization
	void Start () {
		goPlayer = GameObject.Find("NotWalle");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A) && boPuedeBlinkear)
		{
			fDistanciay = goDistancia.transform.position.y - goPlayer.transform.position.y;
			goPlayer.transform.position = new Vector3(0, fDistanciay * 2);
		}
	}
	
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject == goPlayer)
		{
			boPuedeBlinkear = true;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject == goPlayer)
		{
			boPuedeBlinkear = false;
		}
	}
}
