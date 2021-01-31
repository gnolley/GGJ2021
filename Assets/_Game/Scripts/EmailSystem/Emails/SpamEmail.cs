using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class SpamEmail : Email {

		public SpamEmail(Author author,
				string title,
				string subject,
				string bodyText) : base(author,
							title,
							subject,
							bodyText,
							EmailType.Spam) {
		}
	}
}