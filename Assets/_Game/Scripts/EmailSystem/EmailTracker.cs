using System;
using System.Collections.Generic;
using UnityEngine;
using EmailSystem.UI;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailTracker : MonoBehaviour {
		[SerializeField] private GameObject emailEntryPrefab;
		[SerializeField] private RectTransform spawnTransform;

		protected List<Email> EmailList = new List<Email>();
		int currentEmail = 0;

		public Email CurrentEmail {
			get {
				if (currentEmail < EmailList.Count && currentEmail > 0) return EmailList[currentEmail];
				else throw new ArgumentException("Current Email invalid");
			}
		}

		public void AddEmail(Email email, Action<Email> onPressCallback) {
			EmailList.Add(email);
			EmailNotificationView view = Instantiate(emailEntryPrefab, spawnTransform).GetComponent<EmailNotificationView>();
			view.Populate(email, onPressCallback);
		}

		public void RemoveEmail(Email email) {
			EmailList.Remove(email);
		}
	}
}