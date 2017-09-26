using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public InputField Xcent;
	public InputField Ycent;
	public InputField Zoom;
	public InputField Iterations;

	public void Start(){
		Xcent.text = PlayerPrefs.GetFloat ("Xcent").ToString();
		Ycent.text = PlayerPrefs.GetFloat ("Ycent").ToString();
		Zoom.text = PlayerPrefs.GetFloat ("Zoom").ToString();
		Iterations.text = PlayerPrefs.GetFloat ("Iterations").ToString();
	}


	public void Launch(){
		PlayerPrefs.SetFloat ("Xcent", float.Parse(Xcent.text));
		PlayerPrefs.SetFloat ("Ycent", float.Parse(Ycent.text));
		PlayerPrefs.SetFloat ("Zoom", float.Parse(Zoom.text));
		PlayerPrefs.SetFloat ("Iterations", float.Parse(Iterations.text));
		SceneManager.LoadScene ("mandelbrot");
	}
}
