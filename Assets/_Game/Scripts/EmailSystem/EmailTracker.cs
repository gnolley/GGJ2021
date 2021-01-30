using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailTracker : MonoBehaviour {
		protected List<Email> EmailList = new List<Email>();

		public void AddEmail(Email email) {
			EmailList.Add(email);
		}

		public void RemoveEmail(Email email) {
			EmailList.Remove(email);
		}
	}
}