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
	public subDisplay disp1;
	public subDisplay disp2;
	public subDisplay disp3;
	public subDisplay disp4;
	public subDisplay disp5;
	public subDisplay disp6;
	public subDisplay disp7;
	public subDisplay disp8;

	private float xCent;
	private float yCent;
	private float zoom;
	private float iterations;


	public void Start(){
		xCent = PlayerPrefs.GetFloat ("Xcent");
		yCent = PlayerPrefs.GetFloat ("Ycent");
		zoom = PlayerPrefs.GetFloat ("Zoom");
		iterations = PlayerPrefs.GetFloat ("Iterations");
		disp1.Draw (xCent, yCent, zoom, iterations);
		disp2.Draw (xCent, yCent, zoom, iterations);
		disp3.Draw (xCent, yCent, zoom, iterations);
		disp4.Draw (xCent, yCent, zoom, iterations);
		disp5.Draw (xCent, yCent, zoom, iterations);
		disp6.Draw (xCent, yCent, zoom, iterations);
		disp7.Draw (xCent, yCent, zoom, iterations);
		disp8.Draw (xCent, yCent, zoom, iterations);
		Xcent.text = xCent.ToString();
		Ycent.text = yCent.ToString();
		Zoom.text = zoom.ToString();
		Iterations.text = iterations.ToString();
	}


	public void Launch(){

		PlayerPrefs.SetFloat ("Xcent", float.Parse(Xcent.text));
		PlayerPrefs.SetFloat ("Ycent", float.Parse(Ycent.text));
		PlayerPrefs.SetFloat ("Zoom", float.Parse(Zoom.text));
		PlayerPrefs.SetFloat ("Iterations", float.Parse(Iterations.text));
		SceneManager.LoadScene ("mandelbrot");
	}
}
