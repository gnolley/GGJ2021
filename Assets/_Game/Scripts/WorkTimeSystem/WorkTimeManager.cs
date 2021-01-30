using System;
using UnityEngine;

namespace GameSystem.WorkTime {

	/// <summary>
	///
	/// </summary>
	public class WorkTimeManager : MonoBehaviour {

		/// <summary>
		/// 8 hours in seconds
		/// </summary>
		private const float END_WORK_TIME = 28800;

		[SerializeField] private float workTime = 0;

		public float NormalisedProgress => workTime / END_WORK_TIME;

		public bool WorkStarted { get; private set; }

		public TimeInfo CurrentHMS { get; protected set; }

		private void Start() {
			StartTime();
		}

		public void StartTime() {
			workTime = 0;
			CurrentHMS = GetHMS();

			Time.timeScale = 3;

			WorkStarted = true;
		}

		private void Update() {

			if (WorkStarted == false) return;

			workTime += Time.deltaTime;
			CurrentHMS = GetHMS();
		}

		public TimeInfo GetHMS() {
			TimeInfo time = CurrentHMS;

			// Don't know if this is an efficient way of doing this
			time.Hour = (int)workTime / 3600;
			time.Minute = (int)workTime / 60 - time.Hour * 60;
			time.Second = (int)workTime - time.Minute * 60 - time.Hour * 3600;

			CurrentHMS = time;
			return CurrentHMS;
		}
	}

	[System.Serializable]
	public struct TimeInfo {
		public int Hour;
		public int Minute;
		public int Second;
	}
}