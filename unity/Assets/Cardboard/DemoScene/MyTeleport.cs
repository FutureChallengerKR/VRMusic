using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class MyTeleport : MonoBehaviour {
	private Vector3 startingPosition;

	private float gazedTime = 0.0f;
	private bool isCaptured = false;
	
	void Start() {
		startingPosition = transform.localPosition;
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
			TeleportRandomly();
		}

	}
	
	void LateUpdate() {
		Cardboard.SDK.UpdateState();
		if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		}
	}
	
	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

		isCaptured = gazedAt;
	}
	
	public void Reset() {
		transform.localPosition = startingPosition;
	}
	
	public void ToggleVRMode() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}
	
	public void TeleportRandomly() {
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		float distance = 2 * Random.value + 1.5f;
		transform.localPosition = direction * distance;
	}
}
