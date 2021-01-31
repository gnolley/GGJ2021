using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseEmail : Email {
		private Email incorrentResponse;

		public Email IncorrentResponse {
			get { return incorrentResponse; }
			set { incorrentResponse = value; }
		}


		public ResponseEmail(Author author,
				string subject,
				string bodyText,
				Email incorrentResponse) : base(author,
							subject,
							bodyText,
							EmailType.Response) {
			this.incorrentResponse = incorrentResponse;
		}
	}
}