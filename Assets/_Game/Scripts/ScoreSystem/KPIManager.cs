using UnityEngine;

/// <summary>
///
/// </summary>
public class KPIManager : MonoBehaviour {

	/// <summary>
	/// Key performance indicator [0,100?]
	/// </summary>
	public int KPI { get; private set; }

	public void AddScore(int score) {
		// some way of calculating score to add to kpi
	}
}