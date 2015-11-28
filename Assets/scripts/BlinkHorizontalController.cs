using UnityEngine;
using System.Collections;

public class BlinkHorizontalController : MonoBehaviour {

	public GameObject goDistancia;
	GameObject goPlayer;
	GameObject goEscenario;
	public bool boPuedeBlinkear = false;
	public float fDistanciax;

	// Use this for initialization
	void Start () {
		goPlayer = GameObject.Find("Player");
		goEscenario = GameObject.Find("ESCENARIO");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B) && boPuedeBlinkear)
		{
			fDistanciax = goDistancia.transform.position.x - goPlayer.transform.position.x;
			goEscenario.transform.Rotate(new Vector3(0, 500, 0) * Time.deltaTime);
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
