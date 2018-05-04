using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingScript : MonoBehaviour {
	public int komaHP = 5;
	public Text HPLabel;
	public GameObject result;
	public GameObject retry;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		HPLabel.text = "HP:" + komaHP.ToString ();
		if (transform.position.y <= -10 || komaHP == 0) {
			Destroy (this.gameObject);
			result.gameObject.SetActive(true);
			Invoke ("Retry", 1.0f);
		}
	}

	void Retry(){
		retry.SetActive (true);
	}
}
