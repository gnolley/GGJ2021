using System;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailTracker : MonoBehaviour {
		protected List<Email> EmailList = new List<Email>();
		int currentEmail = 0;

		public Email CurrentEmail {
			get {
				if (currentEmail < EmailList.Count && currentEmail > 0) return EmailList[currentEmail];
				else throw new ArgumentException("Current Email invalid");
			}
		}

		public void AddEmail(Email email) {
			EmailList.Add(email);
		}

		public void RemoveEmail(Email email) {
			EmailList.Remove(email);
		}
	}
}