using UnityEngine;
using TMPro;

namespace ScoreSystem {

	/// <summary>
	///
	/// </summary>
	public class ReportView : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI KPIScoreText;
		[SerializeField] private TextMeshProUGUI RatingText;

		private void Start() {
			DisplayScore();
		}

		public void DisplayScore() {
			KPIScoreText.text = KPIManager.instance.KPI.ToString();
			RatingText.text = RatingFunction.Evaluate(KPIManager.instance.KPI);
		}

	}
}