using System;
using UnityEngine;
using GameSystem.WorkTime.UI;
using UnityEngine.Events;
using System.Collections;

namespace GameSystem.WorkTime {

	/// <summary>
	///
	/// </summary>
	public class WorkTimeManager : MonoBehaviour {


		#region Singleton
		public static WorkTimeManager instance;

		private void Awake() {
			if (instance == null)
				instance = this;
			else {
				Debug.LogError("There can only be one instance on WorkTimeManager");
				Destroy(this);
			}
		}
		#endregion Singleton

		[SerializeField] private float workTime = 0;
		[SerializeField] private WorkTimeView view;
		[SerializeField] private float startTime = 9f, endTime = 17f, runTime = 60f;
		[SerializeField] private UnityEvent OnDayFinish = new UnityEvent();

		private float END_WORK_TIME => hoursToSeconds(endTime);
		private float START_WORK_TIME => hoursToSeconds(startTime);
		private float TIME_SCALE => hoursToSeconds(endTime - startTime) / runTime;

		private float secondsToHours(float seconds) => seconds / 3600f;
		private float secondsToMinutes(float seconds) => seconds / 60f;

		private float minutesToSeconds(float minutes) => minutes * 60f;
		private float hoursToSeconds(float hours) => hours * 3600f;

		public float NormalisedProgress => workTime / END_WORK_TIME;

		public bool WorkStarted { get; private set; }

		public TimeInfo CurrentHMS { get; protected set; }

		private void Start() {
			StartTime();
		}

		public void StartTime() {
			workTime = START_WORK_TIME;
			CurrentHMS = GetHMS();

			WorkStarted = true;
			StopCoroutine(nameof(TimerLoop));
			StartCoroutine(nameof(TimerLoop));
		}

		IEnumerator TimerLoop() {
			while (true) {
				if (!WorkStarted) yield return null;

				workTime += Time.deltaTime * TIME_SCALE;
				CurrentHMS = GetHMS();

				if(workTime >= END_WORK_TIME) {
					workTime = END_WORK_TIME;
					CurrentHMS = GetHMS();
					EndDay();
				}

				yield return null;
			}
		}

		private void EndDay() {
			StopCoroutine(nameof(TimerLoop));
			OnDayFinish.Invoke();
		}

		public TimeInfo GetHMS() {
			TimeInfo time = CurrentHMS;

			// Don't know if this is an efficient way of doing this
			time.Hour = (int)workTime / 3600;
			time.Minute = (int)workTime / 60 - time.Hour * 60;
			time.Second = (int)workTime - time.Minute * 60 - time.Hour * 3600;

			CurrentHMS = time;
			view.SetWorkTime(CurrentHMS);
			return CurrentHMS;
		}
	}

	[System.Serializable]
	public struct TimeInfo {
		public int Hour;
		public int Minute;
		public int Second;

		public override string ToString() {
			string builder = "";
			if(Hour < 10) builder += "0";
			builder += Hour.ToString();

			builder += ":";

			if(Minute < 10) builder += "0";
			builder += Minute.ToString();

			return builder;
		}
	}
}
