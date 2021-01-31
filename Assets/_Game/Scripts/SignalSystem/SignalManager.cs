using UnityEngine;
using SignalSystem.UI;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalManager : MonoBehaviour {

		private const float Y_THRESHOLD = 0.05f;
		private readonly Vector2 ROLL_RANGE = new Vector2(-0.4f, 0.4f);

		private const float MAX_DISTANCE_THRESHOLD = 0.2f;

		[SerializeField] private SignalView view;

		public float EvaluatedSignalStrength { 
			get {
				if (!Application.isEditor) return SignalStrength;
				else return 1f;
			}
		}

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

			view.SetSignalLevel((int)(EvaluatedSignalStrength * 3 + 0.5f));
		}

		private void ChooseNewSignalPosition() {
			CurrentSignalPosition = new Vector2(
				Random.Range(ROLL_RANGE.x, ROLL_RANGE.y),
				Y_THRESHOLD
				);

			NewSignalChosenEvent?.Invoke(CurrentSignalPosition);
		}

		public void OnStartUploadingHandler() {
			ChooseNewSignalPosition();
		}
	}
}