using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseEmail : Email {
		private InquiryEmail incorrentResponse;

		public InquiryEmail IncorrentResponse {
			get { return incorrentResponse; }
			set { incorrentResponse = value; }
		}


		public ResponseEmail(Author author,
				string title,
				string subject,
				string bodyText,
				InquiryEmail incorrentResponse) : base(author,
							title,
							subject,
							bodyText,
							EmailType.Response) {
			this.incorrentResponse = incorrentResponse;
		}
	}
}