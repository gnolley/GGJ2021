using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class InfoEmail : Email {

		private EmailInfo associatedInfo;

		public EmailInfo AssociatedInfo {
			get { return associatedInfo; }
			set { associatedInfo = value; }
		}


		public InfoEmail(Author author,
				string title,
				string subject,
				string bodyText,
				EmailInfo emailInfo) : base(author,
							title,
							subject,
							bodyText,
							EmailType.Info) {
			associatedInfo = emailInfo;
		}
    }
}