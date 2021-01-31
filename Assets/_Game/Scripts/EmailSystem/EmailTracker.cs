using System;
using System.Collections.Generic;
using UnityEngine;
using EmailSystem.UI;
using System.Linq;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailTracker : MonoBehaviour {
		[SerializeField] private GameObject emailEntryPrefab;
		[SerializeField] private RectTransform spawnTransform;

		protected List<Email> EmailList = new List<Email>();
		
		private Email currentEmail;
		public Email CurrentEmail {
			get {
				if (currentEmail != null) return currentEmail;
				else throw new NullReferenceException("No current email set");
			}
			set => currentEmail = value;
		}

		public void AddEmail(Email email, Action<Email> onPressCallback) {
			EmailList.Add(email);
			EmailNotificationView view = Instantiate(emailEntryPrefab, spawnTransform).GetComponent<EmailNotificationView>();
			view.Populate(email, onPressCallback);
		}

		public int InfoEmailCount => EmailList.Where((x) => x.EmailType == EmailType.Info).Count();
		public int InquiryEmailCount => EmailList.Where((x) => x.EmailType == EmailType.Inquiry).Count();
		public int TotalEmailCount => EmailList.Count;

		/// <summary>
		/// Gets a random email in the list of emails that is an info email
		/// </summary>
		public InfoEmail GetRandomInfoEmail() {
			IEnumerable<Email> emails = EmailList.Where((x) => x.EmailType == EmailType.Info);
			if (emails.Count() <= 0) throw new NullReferenceException("There are no info emails in the email list");

			int randomEmail = UnityEngine.Random.Range(0, emails.Count());
			if (!(emails.ElementAt(randomEmail) is InfoEmail))
				throw new ArgumentException("There is an email marked as info, that is not an InfoEmail");

			return emails.ElementAt(randomEmail) as InfoEmail;
		}

		public void RemoveEmail(Email email) {
			EmailList.Remove(email);
		}
	}
}