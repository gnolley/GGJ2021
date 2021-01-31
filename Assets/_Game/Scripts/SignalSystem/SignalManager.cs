using UnityEngine;

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

		private readonly Vector2 ROLL_RANGE = new Vector2(-0.3f, 0.3f);
		private readonly Vector2 PITCH_RANGE = new Vector2(0, 0.3f);

		private const float DISTANCE_THRESHOLD = 0.13f;

		/// <summary>
		/// The current signal strength [0,1]
		/// </summary>
		public float CurrentSignalStrength { get; private set; } = 1;

		public Vector2 CurrentSignalPosition { get; private set; }

		private Transform cube;

		// when to shift signal
		// bounds
		// relative position

		private void Awake() {
			GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			newObject.GetComponent<Collider>().enabled = false;
			cube = newObject.transform;

			ChooseNewSignalPosition();
		}

		public void Reset() {
			// reset variables
		}

		public void UpdateSignal(Vector2 finderPosition) {

			// check against current position
			CurrentSignalStrength = (CurrentSignalPosition - finderPosition).magnitude;

			if (CurrentSignalStrength <= DISTANCE_THRESHOLD) ChooseNewSignalPosition();
		}

		private void ChooseNewSignalPosition() {
			Vector2 newPos = new Vector2(
				Random.Range(ROLL_RANGE.x, ROLL_RANGE.y),
				Random.Range(PITCH_RANGE.x, PITCH_RANGE.y)
				);

			CurrentSignalPosition = newPos;
			cube.position = CurrentSignalPosition;
		}

	}
}