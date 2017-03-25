using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTilt : MonoBehaviour {

	public GameObject menu;
	private bool isShowing;
	public Text sliderValue;
	public Slider slider;

	// Use this for initialization
	void Start () {
		menu.SetActive (isShowing);
		sliderValue.enabled = isShowing;
		bool touchy = Input.multiTouchEnabled;
		Debug.Log ("We can touch:" + touchy);
		sliderValue = GetComponentInChildren<Text> ();
		slider = menu.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {

		sliderValue.text = slider.value.ToString();

		int nbTouches = Input.touchCount;

		if (nbTouches > 0)
			Debug.Log ("Touched Again!");
		if (Input.GetMouseButtonDown (0)) {
			menu.SetActive (!isShowing);
			sliderValue.enabled = !isShowing;
		}
		
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				menu.SetActive (!isShowing);
				sliderValue.enabled = !isShowing;
			}
		}
			
	}
}
