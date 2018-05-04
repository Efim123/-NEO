using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour {
	public GameObject retryButton;
	public int mainflag = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainflag == 2) {
			SceneManager.LoadScene ("Main");
		}
	}

	public void RetryButton(){
		mainflag = 2;
	}
}
