using UnityEngine;
using System.Collections;

public class PlataformaController : MonoBehaviour {

    public float speed;
    public int max;
    public int min;

    private int flag;
    private int count;
	// Use this for initialization
	void Start () {
        speed = 0;
        flag = 0;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (flag == 0)
        {
            transform.localPosition += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
            count++;
        }
        if (flag == 1)
        {
            transform.localPosition -= new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
            count--;
        }
        if (count >= max)
            flag = 1;
        if (count <= min)
            flag = 0;
	}
}
