using UnityEngine;
using UnityEngine.UI;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalFinder : MonoBehaviour {

		public bool GyroAvailable { get; private set; }

		private void Awake() {
			GyroAvailable = SystemInfo.supportsAccelerometer;

			if (SystemInfo.supportsGyroscope) {
				Input.gyro.enabled = true;
			}

			// check gyro
			// check system
		}

		private void Update() {
			// check gyro
			// check system
			// update manager

			Vector3 dir = Input.acceleration;
			Vector3 gravity = Input.gyro.gravity;

			Vector3 result = new Vector3();
			result.x = dir.x;
			result.y += (dir - gravity).y;
			result.z = 0;

			// Move object
			transform.position = Vector3.Lerp(transform.position, result, 0.3f);

			SignalManager.Instance.UpdateSignal(transform.position);
		}
	}
}