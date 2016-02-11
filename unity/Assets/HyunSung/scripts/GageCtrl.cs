using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class GageCtrl : MonoBehaviour {
	private Vector3 startingPosition;

	private float gazedTime = 0.0f;
	private bool isCaptured = false;

	private AudioSource bgm;
	public AudioClip musik1;

	public GameObject playlist1;
	public GameObject Level;

	void Start() {
		bgm = GetComponent<AudioSource>();
		SetGazedAt(false);
		//Level.SetActive (false);
	}

	void Update() {
		if (isCaptured) {
			gazedTime += Time.deltaTime;
		} else {
			gazedTime = 0.0f;
		}

		if (gazedTime > 1.5f && isCaptured) {
			gazedTime = 0.0f;
			isCaptured = false;
			Level.SetActive (true);
			playMs ();
			//TeleportRandomly();
		}


	}

	void LateUpdate() {
		Cardboard.SDK.UpdateState();
		if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.black : Color.gray;

		isCaptured = gazedAt;
	}
	public void playMs(){
		bgm.PlayOneShot (musik1, 1.0f);

	}
}
