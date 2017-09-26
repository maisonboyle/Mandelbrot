using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mandelbrot : MonoBehaviour {

	public Renderer rend;

	public void Start(){
		rend = GetComponent<Renderer> ();
		rend.material.SetFloat ("Xcent", PlayerPrefs.GetFloat("Xcent"));
		rend.material.SetFloat ("Ycent", PlayerPrefs.GetFloat("Ycent"));
		rend.material.SetFloat ("Zoom", PlayerPrefs.GetFloat("Zoom"));
		rend.material.SetFloat ("Iterations", PlayerPrefs.GetFloat("Iterations"));
	}

	public void Back(){
		SceneManager.LoadScene ("menu");
	}
}
