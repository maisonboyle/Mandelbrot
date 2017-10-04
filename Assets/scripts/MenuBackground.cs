using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour {

	public Renderer rend;
	public Camera cam;
	private float xCent;
	private float yCent;
	private float zoom;
	private float iterations;
	private CameraClearFlags clearFlags;
	private int cullingMask;
	private float preTouch;

	public void Start(){
		cam.clearFlags = CameraClearFlags.Skybox;
		cam.cullingMask = -1;
		xCent = PlayerPrefs.GetFloat ("Xcent");
		yCent = PlayerPrefs.GetFloat ("Ycent");
		zoom = PlayerPrefs.GetFloat ("Zoom");
		iterations = PlayerPrefs.GetFloat ("Iterations");
		preTouch = zoom;
		rend = GetComponent<Renderer> ();
		rend.material.SetFloat ("Xcent", xCent);
		rend.material.SetFloat ("Ycent", yCent);
		rend.material.SetFloat ("Zoom", zoom);
		rend.material.SetFloat ("Iterations", iterations);
		clearFlags = cam.clearFlags;
		cullingMask = cam.cullingMask;
		Invoke ("Freeze", iterations/100f);
	}

	private void Freeze(){
		cam.clearFlags =  CameraClearFlags.Nothing;
		cam.cullingMask = 0;
	}
}
