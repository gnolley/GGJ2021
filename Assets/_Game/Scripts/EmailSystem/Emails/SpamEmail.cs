using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class SpamEmail : Email {

		public SpamEmail(Author author,
				string subject,
				string bodyText) : base(author,
							subject,
							bodyText,
							EmailType.Spam) {
		}
	}
}