using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameSystem.WorkTime.UI {
    public class WorkTimeView : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI timeText;

		public void SetWorkTime(TimeInfo info) {
			timeText.text = $"{info.Hour}:{info.Minute}";
		}

	}
}