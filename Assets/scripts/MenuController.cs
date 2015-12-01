using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
    Renderer r;
    MovieTexture movie;
	void Start () {
        r = GetComponent<Renderer>();
         movie = (MovieTexture)r.material.mainTexture;

         movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
           
	}
    public void LoadGame()
    {
        Application.LoadLevel(0);
    }
}
