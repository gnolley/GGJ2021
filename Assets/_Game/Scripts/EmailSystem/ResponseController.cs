using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.UI {
	public class ResponseController : MonoBehaviour {

		[SerializeField] private List<ResponseView> responseViews = new List<ResponseView>(3);
		const int RESPONSE_AMOUNT = 3;

		/// <summary>
		/// Populate the response fields
		/// </summary>
		/// <param name="falseResponses">A list of info of SIZE 3 to populate responses</param>
		public void PopulateResponses(EmailInfo correntAnswer, EmailInfo[] falseResponses) {
			int trueAnswer = Random.Range(0, RESPONSE_AMOUNT);
			int falseResponsesUsed = 0;

			for(int i=0; i< RESPONSE_AMOUNT; ++i) {
				if (i != trueAnswer) {
					responseViews[i].SetResponseInfo(falseResponses[falseResponsesUsed]);
					falseResponsesUsed++;
				}
				else responseViews[i].SetResponseInfo(correntAnswer);
			}
		}
	}
}
