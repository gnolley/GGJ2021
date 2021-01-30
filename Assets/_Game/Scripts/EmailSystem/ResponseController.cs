using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.UI {
	public class ResponseController : MonoBehaviour {

		[SerializeField] private List<ResponseView> responseViews = new List<ResponseView>(3);
		[SerializeField] private EmailUploader uploader;
		public const int RESPONSE_AMOUNT = 3;

		/// <summary>
		/// Populate the response fields
		/// </summary>
		/// <param name="falseResponses">A list of info of SIZE 3 to populate responses</param>
		public void PopulateResponses(EmailInfo[] responses) {
			for(int i=0; i< RESPONSE_AMOUNT; ++i) {
				responseViews[i].SetResponseInfo(responses[i]);
			}
		}


		public void OnResponsePress(EmailInfo responseInfo) {
			uploader.ResponseChosen(responseInfo);
		}
	}
}
