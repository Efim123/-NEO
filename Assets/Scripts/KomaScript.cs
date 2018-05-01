using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KomaScript : MonoBehaviour {
	public int komaHP = 1;
	public Text HPLabel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//HPLabel.text = "HP:" + komaHP.ToString ();
		if (transform.position.y <= -10 || komaHP ==0){
			Destroy (this.gameObject);
		}
	}
}
