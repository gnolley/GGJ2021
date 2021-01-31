using UnityEngine;
using UnityEngine.Events;

namespace SignalSystem {

	/// <summary>
	///
	/// </summary>
	public class SignalManager : MonoBehaviour {

		#region Singleton

		private static SignalManager instance;

		public static SignalManager Instance {
			get {
				Init();
				return instance;
			}
			private set { instance = value; }
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init() {
			// Unity replaces a destroyed game object with a non-null "destroyed" object.
			// Using .Equals checks against that.
			if (instance == null || instance.Equals(null)) {
				GameObject gameObject = new GameObject("Spawned SignalManager");
				instance = gameObject.AddComponent<SignalManager>();
				DontDestroyOnLoad(gameObject);

				Debug.LogFormat("Spawned new {0} singleton", typeof(SignalManager));
			}
		}

		#endregion Singleton

		private const float Y_THRESHOLD = 0.12f;
		private readonly Vector2 ROLL_RANGE = new Vector2(-0.4f, 0.4f);

		private const float MAX_DISTANCE_THRESHOLD = 0.25f;

		/// <summary>
		/// The current signal strength [0,1]
		/// </summary>
		public float CurrentSignalStrength { get; private set; } = 1;

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
		}

		public void UpdateSignal(Vector2 finderPosition) {
			float yStrength = Mathf.InverseLerp(0, Y_THRESHOLD, finderPosition.y);

			float xDistance = Mathf.Abs(CurrentSignalPosition.x - finderPosition.x);
			float xStrength = Mathf.InverseLerp(MAX_DISTANCE_THRESHOLD, 0, xDistance);

			// check against current position
			CurrentSignalStrength = yStrength * xStrength;

			if (CurrentSignalStrength >= 0.9f) ChooseNewSignalPosition();
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