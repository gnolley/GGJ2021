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

		/// <summary>
		/// The current signal strength [0,1]
		/// </summary>
		public float CurrentSignal { get; private set; } = 1;

		// when to shift signal
		// bounds
		// relative position

		public void Reset() {
			// reset variables
		}

		public void UpdateSignal(float someDirection) {
			// check against current position
		}
	}
}