using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
	public GameObject startButton;
	public int titleflag = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (titleflag == 2) {
			SceneManager.LoadScene ("Main");
		}
	}

	public void StartButton(){
		titleflag = 2;
	}
}
