using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0f, 40f, 0f) * Time.deltaTime;
	}
}
