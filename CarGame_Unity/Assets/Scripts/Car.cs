using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Cars {
	public class Car : MonoBehaviour {

		public WheelCollider[] frontWheels;
		public WheelCollider[] backWheels;
		private WheelCollider[] allWheels;

		public float acceleration;
		public float brake;
		public float steeringAngle;

		// Use this for initialization
		void Start() {
			allWheels = new WheelCollider[] { backWheels[0], backWheels[1], frontWheels[0], frontWheels[1] };
		}

		// Update is called once per frame
		void Update() {
			float a = Input.GetKey("space") ? 0 : Input.GetKey("w") ? 1 : 0.15f;
			float s = Input.GetKey("a") ? -steeringAngle : Input.GetKey("d") ? steeringAngle : 0; //Input.gyro.attitude.???
			foreach(WheelCollider w in backWheels) w.motorTorque = acceleration * a;
			foreach(WheelCollider w in allWheels) w.brakeTorque = Input.GetKey("s") ? brake : 0;
			foreach(WheelCollider w in frontWheels) w.steerAngle = Mathf.Lerp(w.steerAngle, s, Time.deltaTime*5f);
		}
	}
}
