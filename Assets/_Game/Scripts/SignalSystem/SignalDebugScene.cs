using UnityEngine;
using UnityEngine.UI;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalDebugScene : MonoBehaviour {

		[SerializeField] private Text accelText;
		[SerializeField] private Text strengthText;
		[SerializeField] private Text posText;
		[SerializeField] private Text resultText;
		[SerializeField] private Text gravityText;

		private Vector3 result = new Vector3();

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

			// clamp acceleration vector to unit sphere
			//if (dir.sqrMagnitude > 1)
			//	dir.Normalize();

			accelText.text = $"a: {dir.ToString()}";

			result.x = dir.x;
			result.y += (dir - gravity).y * Time.deltaTime;
			result.z = 0;

			resultText.text = $"r: {result.ToString()}";

			// Move object
			transform.position = Vector3.Lerp(transform.position, result, 0.3f);
			//transform.Translate(result * Time.deltaTime * 3);

			SignalManager.Instance.UpdateSignal(transform.position);

			strengthText.text = SignalManager.Instance.CurrentSignalStrength.ToString();
			posText.text = SignalManager.Instance.CurrentSignalPosition.ToString();

			gravityText.text = $"grav: {Input.gyro.gravity}";
		}
	}
}