using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsController : MonoBehaviour {

	public GameObject goFondo;
	public GameObject goCreditos;
    GameObject goPlayer;
	Animator animCreditos;
	bool primerLoop = false;

	// Use this for initialization
	void Start () {
        goPlayer = GameObject.Find("NotWalle");
		animCreditos = goCreditos.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (animCreditos.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !primerLoop)
		{
            goCreditos.GetComponent<Image>().CrossFadeAlpha(0, 5, false);
			goFondo.GetComponent<Image>().CrossFadeAlpha(0, 5, false);
            goPlayer.GetComponent<NotWalleController>().introCompleted = true;
			primerLoop = true;
		}
	}
}
