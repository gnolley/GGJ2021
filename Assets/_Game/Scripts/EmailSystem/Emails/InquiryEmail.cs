using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class InquiryEmail : Email {

		private EmailInfo infoToAquire;

		public EmailInfo InfoToAquire {
			get { return infoToAquire; }
			set { infoToAquire = value; }
		}


		public InquiryEmail(Author author,
				string subject,
				string bodyText,
				EmailInfo emailInfo) : base(author,
							subject,
							bodyText,
							EmailType.Inquiry) {
			infoToAquire = emailInfo;	
		}
	}
}