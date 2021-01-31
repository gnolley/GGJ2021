using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseGenerator : MonoBehaviour {
		public EmailInfo GenerateInfoEmailResponse() {
			return new EmailInfo("Info Response", EmailInfo.InfoTypeEnum.Place);
		}

		public EmailInfo GenerateInquiryEmailResponse(EmailInfo.InfoTypeEnum type) { 
			return new EmailInfo("Inquiry Response", type);
		}

		public EmailInfo GenerateSpamEmailResponse() { 
			return new EmailInfo("Spam Response", EmailInfo.InfoTypeEnum.Place);
		}
		public EmailInfo GenerateResponseEmailResponse() { 
			return new EmailInfo("Angry Response", EmailInfo.InfoTypeEnum.Place);
		}
	}
}
