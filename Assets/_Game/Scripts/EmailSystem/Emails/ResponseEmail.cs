using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseEmail : Email {
		private EmailInfo incorrentResponse;

		public EmailInfo IncorrentResponse {
			get { return incorrentResponse; }
			set { incorrentResponse = value; }
		}


		public ResponseEmail(Author author,
				string subject,
				string bodyText,
				EmailInfo incorrentResponse) : base(author,
							subject,
							bodyText,
							EmailType.Response) {
			this.incorrentResponse = incorrentResponse;
		}
	}
}