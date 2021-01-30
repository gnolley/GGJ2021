using UnityEngine;
using UnityEngine.UI;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalFinder : MonoBehaviour {

        [SerializeField] private Text accelText;
        [SerializeField] private Text strengthText;
        [SerializeField] private Text posText;
        [SerializeField] private Text resultText;

		public bool GyroAvailable { get; private set; }

		private void Awake() {
			GyroAvailable = SystemInfo.supportsAccelerometer;

			// check gyro
			// check system
		}

		private void Update() {
			// check gyro
			// check system
			// update manager

			Vector3 dir = Input.acceleration;

			// clamp acceleration vector to unit sphere
			//if (dir.sqrMagnitude > 1)
			//	dir.Normalize();

			accelText.text = $"a: {dir.ToString()}";

			Vector3 result = new Vector3();
			result.x = dir.x;
			result.y = dir.z;

			resultText.text = $"r: {result.ToString()}";

			SignalManager.Instance.UpdateSignal(result);

			// Move object
			transform.position = result * 3;



			strengthText.text = SignalManager.Instance.CurrentSignalStrength.ToString();
			posText.text = SignalManager.Instance.CurrentSignalPosition.ToString();
		}
	}
}