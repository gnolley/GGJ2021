﻿using UnityEngine;
using ScoreSystem.UI;

namespace ScoreSystem {
	/// <summary>
	///
	/// </summary>
	public class KPIManager : MonoBehaviour {
		#region Singleton
		public static KPIManager instance;

		private void Awake() {
			if (instance == null)
				instance = this;
			else {
				Debug.LogError("There can only be one instance on KPIManager");
				Destroy(this);
			}
		}
		#endregion Singleton

		[SerializeField] private float infoCorrect = 10f, inquiryCorrect = 25f, inquiryIncorrect = 5f;
		[SerializeField] private KPIView view;

		const float MAX_KPI = 100f;

		float kpi = 0f;
		/// <summary>
		/// Key performance indicator [0,100?]
		/// </summary>
		public float KPI { 
			get => kpi;
			private set {
				kpi = Mathf.Clamp(kpi + value, 0f, MAX_KPI);
				view.SetKPI(Mathf.Round(kpi / MAX_KPI));
			}
		}

		private void Start() {
			KPI = MAX_KPI;
		}

		public void AddCorrectInfoResponse() => KPI += infoCorrect;
		public void AddCorrentInquiryResponse() => KPI += inquiryCorrect;
		public void AddIncorrectInquiryResponse() => KPI -= inquiryIncorrect;
	}
}