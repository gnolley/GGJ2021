using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EmailSystem.UI {
	public class ResponseView : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI responseText;

		public void SetResponseInfo(EmailInfo info) {
			responseText.text = info.InfoText;
		}
	}
}
