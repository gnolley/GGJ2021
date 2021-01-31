using UnityEngine;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalFinder : MonoBehaviour {

		[SerializeField] private SignalManager manager;

		private Vector3 result = new Vector3();

		private Vector3 finderPosition = new Vector3();

		public bool GyroAvailable { get; private set; }

		private void Awake() {
			GyroAvailable = SystemInfo.supportsAccelerometer;

			if (SystemInfo.supportsGyroscope) {
				Input.gyro.enabled = true;
			}

			manager.NewSignalChosenEvent?.AddListener(OnNewSignalChosen);
		}

		private void OnDestroy() {
			manager.NewSignalChosenEvent?.RemoveListener(OnNewSignalChosen);
		}

		private void Update() {

			Vector3 dir = Input.acceleration;
			Vector3 gravity = Input.gyro.gravity;

			result.x = dir.x;
			result.y += (dir - gravity).y * Time.deltaTime * 4;
			result.y = Mathf.Clamp01(result.y);

			// Move object
			finderPosition = Vector3.Lerp(finderPosition, result, 0.3f);
			manager.UpdateSignal(finderPosition);
		}

		private void OnNewSignalChosen(Vector2 signalPosition) {
			result.y = 0; // reset y
		}
	}
}