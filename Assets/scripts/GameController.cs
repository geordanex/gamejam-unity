using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float count = 0;
    public string Text;
    //public Component Count;
    public GameObject texto;

    private Text contador;

	// Use this for initialization
	void Start () {
        contador = texto.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        contador.text = count.ToString();
	}
   
}
