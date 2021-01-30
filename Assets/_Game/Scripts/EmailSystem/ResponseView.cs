using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EmailSystem.UI {
	public class ResponseView : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI responseText;
		[SerializeField] private ResponseController responseController;

		EmailInfo info;

		public void SetResponseInfo(EmailInfo info) {
			this.info = info;
			responseText.text = info.InfoText;
		}

		public void OnPress() => responseController.OnResponsePress(info);
	}
}
