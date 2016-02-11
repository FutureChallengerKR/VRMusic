using UnityEngine;
using System.Collections;

public class HardLevel : MonoBehaviour {
	private float gazedTime = 0.0f;
	private bool isCaptured = false;

	void Start() {
		SetGazedAt(false);
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
			//Application.LoadLevel ();
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
}
