using UnityEngine;
using System.Collections;

public class CameraArm : MonoBehaviour {
	
	public Camera playerCam;
	public Rigidbody playerRigid;
	public float topY;
	public float botY;
	public float frontZ;
	public float backZ;
	public float midZ;

	public float angX;
	public float angY;
	public float angZ;

	void Update () {
		angX = playerRigid.angularVelocity.x;
		angY = playerRigid.angularVelocity.y;
		angZ = playerRigid.angularVelocity.z;

		
	}
}
