using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseGenerator : MonoBehaviour {
		public EmailInfo GenerateInfoEmailResponse() {
			return new EmailInfo("Info Response");
		}

		public EmailInfo GenerateInquiryEmailResponse() { 
			return new EmailInfo("Inquiry Response");
		}

		public EmailInfo GenerateSpamEmailResponse() { 
			return new EmailInfo("Spam Response");
		}
		public EmailInfo GenerateResponseEmailResponse() { 
			return new EmailInfo("Angry Response");
		}
	}
}
