using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	//public Color playerColor;
	bool onMobile;
	public Rigidbody rigid;
	public float speed;
	public float rotateSpeed;
	//public ParticleSystem particles;
	GameObject mainCam;

	void Start() {
		if (SystemInfo.deviceType == DeviceType.Handheld) {
			Input.gyro.enabled = true;
			onMobile = true;
		}
		else {
			onMobile = false;
		}
		rigid.velocity = speed * Vector3.forward;
		//particles.startColor = playerColor;
		//particles.Play();
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		mainCam.SetActive(false);
	}

	void Update() {
		if(onMobile) {
			player.transform.rotation = Input.gyro.attitude;
		}
		else {
			float horiz = Input.GetAxis("Horizontal");
			float vert = -1 * Input.GetAxis("Vertical");
			rigid.AddTorque((horiz * rotateSpeed * player.transform.up + vert * rotateSpeed * player.transform.right), ForceMode.VelocityChange);
			//player.transform.Rotate(new Vector3(vert * rotateSpeed, horiz * rotateSpeed, 0.0f));
			rigid.velocity = speed * player.transform.forward;
		}
	}

	void OnDestroy(){
		mainCam.SetActive(true);
		Destroy(player);
	}
}