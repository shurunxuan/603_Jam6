using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditSccreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("SampleScene");
        }
	}
}
