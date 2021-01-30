using UnityEngine;
using EmailSystem.UI;
using System.Collections;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailController : MonoBehaviour {

		[SerializeField] private EmailContentView emailContentView;
		[SerializeField] private EmailTracker emailTracker;
		[SerializeField] private EmailGenerator emailGenerator;
		[SerializeField] private UIScreenManager uIScreenManager;

		[SerializeField] private int startingEmail = 3;
		[SerializeField] private float infoToInquryFactor = 0.6f, spamEmailChance;
		[SerializeField] private float newEmailEvery = 4f;


		[SerializeField] private int maxEmails = 10;
		const int MINIMUM_ACTIVE_INFO = 3;

		private void Start() {
			Init();
		}

		private void Init() { 
		
			for(int i=0; i<startingEmail; ++i) {
				AddNewInfoEmail();
			}


			StopCoroutine(nameof(EmailTicker));
			StartCoroutine(nameof(EmailTicker));
		}

		IEnumerator EmailTicker() {
			while (true) {
				yield return new WaitForSeconds(newEmailEvery);
				SpawnRandomEmail();
			}
		}

		public void SpawnRandomEmail() {
			if(emailTracker.TotalEmailCount >= maxEmails) return;

			float spam = Random.Range(0f, 1f);
			if(spam <= spamEmailChance) {
				AddNewSpamEmail();
				return;
			}

			int infoActive = emailTracker.InfoEmailCount;

			if(infoActive < MINIMUM_ACTIVE_INFO) {
				AddNewInfoEmail();
				return;
			}

			int inquiryActive = emailTracker.InquiryEmailCount;

			float infoToInquiryRatio = infoActive / Mathf.Max(inquiryActive, 1);

			if(infoToInquiryRatio < infoToInquryFactor) AddNewInfoEmail();
			else AddNewInquiryEmail(emailTracker.GetRandomInfoEmail());
		}

				
		private void AddNewInfoEmail() => emailTracker.AddEmail(emailGenerator.GenerateInfoEmail(), OnEmailPress);
		private void AddNewInquiryEmail(InfoEmail basedOn) => emailTracker.AddEmail(emailGenerator.GenerateInquiryEmail(basedOn.AssociatedInfo), OnEmailPress);
		private void AddNewSpamEmail() => emailTracker.AddEmail(emailGenerator.GenerateSpamEmail(), OnEmailPress);

		public void OnEmailPress(Email email) {
			emailContentView.SetContents(email);
			uIScreenManager.GoToScreen(UIScreenManager.UIScreens.EmailScreen);
			email.IsEmailRead = true;
		}

		public void OnTrashPress(Email email) {
			emailTracker.RemoveEmail(email);
		}

		public void OnResponseSent(EmailInfo info) {
			// TODO: Remember what this does
		}
	}
}