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
		private Vector3 finderPosition = new Vector3();

		private void Awake() {

			if (SystemInfo.supportsGyroscope) {
				Input.gyro.enabled = true;
			}
			SignalManager.Instance.NewSignalChosenEvent?.AddListener(OnNewSignalChosen);
		}

		private void OnDestroy() {
			SignalManager.Instance.NewSignalChosenEvent?.RemoveListener(OnNewSignalChosen);
		}

		private void Update() {
			Vector3 dir = Input.acceleration;
			Vector3 gravity = Input.gyro.gravity;

			accelText.text = $"a: {dir.ToString()}";

			result.x = dir.x;
			result.y += (dir - gravity).y * Time.deltaTime * 4;
			result.y = Mathf.Clamp01(result.y);

			resultText.text = $"r: {result.ToString()}";

			// Move object
			finderPosition = Vector3.Lerp(finderPosition, result, 0.3f);
			transform.position = finderPosition;

			//SignalManager.Instance.UpdateSignal(transform.position);

			strengthText.text = SignalManager.Instance.CurrentSignalStrength.ToString();
			posText.text = SignalManager.Instance.CurrentSignalPosition.ToString();

			gravityText.text = $"grav: {Input.gyro.gravity}";
		}

		private void OnNewSignalChosen(Vector2 signalPosition) {
			result.y = 0; // reset y
		}
	}
}