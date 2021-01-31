using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

namespace ScoreSystem {

	/// <summary>
	///
	/// </summary>
	public class ReportView : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI KPIScoreText;
		[SerializeField] private TextMeshProUGUI RatingText;
		[SerializeField, Scene] private string gameScene;

		private void Start() {
			DisplayScore();
		}

		public void DisplayScore() {
			KPIScoreText.text = ((int)KPIManager.instance.KPI).ToString();
			RatingText.text = RatingFunction.Evaluate(KPIManager.instance.KPI);
		}

		public void OnPlayAgainButton() {
			SceneManager.LoadScene(gameScene);
		}
	}
}