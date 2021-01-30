using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreSystem.UI {
    public class KPIView : MonoBehaviour {
		[SerializeField] private RectTransform bar, fill;


		/// <summary>
		/// Sets the KPI to a value as a 0-1 percentage
		/// </summary>
		public void SetKPI(float valueAsPercentage) {
			float newWidth = Mathf.Lerp(0f, bar.rect.width, valueAsPercentage);
			fill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
		}

	}
}
