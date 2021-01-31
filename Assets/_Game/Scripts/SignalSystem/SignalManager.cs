using UnityEngine;
using SignalSystem.UI;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalManager : MonoBehaviour {

		private const float Y_THRESHOLD = 0.12f;
		private readonly Vector2 ROLL_RANGE = new Vector2(-0.4f, 0.4f);

		private const float MAX_DISTANCE_THRESHOLD = 0.3f;

		[SerializeField] private SignalView view;

		public float EvaluatedSignalStrength => SignalStrength;

		/// <summary>
		/// The current signal strength [0,1]
		/// </summary>
		private float SignalStrength { get; set; } = 1;

		public Vector2 CurrentSignalPosition { get; private set; }

		public readonly ReturnEvent<Vector2> NewSignalChosenEvent = new ReturnEvent<Vector2>();

		private void Start() {
			ChooseNewSignalPosition();
		}

		private void OnDestroy() {
			NewSignalChosenEvent?.RemoveAllListeners();
		}

		public void Reset() {
			// reset variables
			SignalStrength = 0;
			ChooseNewSignalPosition();
		}

		public void UpdateSignal(Vector2 finderPosition) {
			float yStrength = Mathf.InverseLerp(0, Y_THRESHOLD, finderPosition.y);

			float xDistance = Mathf.Abs(CurrentSignalPosition.x - finderPosition.x);
			float xStrength = Mathf.InverseLerp(MAX_DISTANCE_THRESHOLD, 0, xDistance);

			// check against current position
			SignalStrength = yStrength * xStrength;

			view.SetSignalLevel((int)((EvaluatedSignalStrength + 0.5f) * 3));

			if (SignalStrength >= 0.9f) ChooseNewSignalPosition();
		}

		private void ChooseNewSignalPosition() {
			CurrentSignalPosition = new Vector2(
				Random.Range(ROLL_RANGE.x, ROLL_RANGE.y),
				Y_THRESHOLD
				);

			NewSignalChosenEvent?.Invoke(CurrentSignalPosition);
		}

	}
}