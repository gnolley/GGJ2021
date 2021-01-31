using UnityEngine;
using EmailSystem.UI;
using System.Collections;
using System.Collections.Generic;
using ScoreSystem;

namespace EmailSystem {

	public class EmailController : MonoBehaviour {

		[SerializeField] private EmailContentView emailContentView;
		[SerializeField] private EmailTracker emailTracker;
		[SerializeField] private EmailGenerator emailGenerator;
		[SerializeField] private UIScreenManager uIScreenManager;
		[SerializeField] private ResponseController responseController;
		[SerializeField] private ResponseGenerator responseGenerator;

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

			float spam = UnityEngine.Random.Range(0f, 1f);
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
		private void AddNewResponseEmail(Email basedOn) => emailTracker.AddEmail(emailGenerator.GenerateResponseEmail(basedOn), OnEmailPress);


		public void OnEmailPress(Email email) {
			emailContentView.SetContents(email);
			GenerateResponses(email);
			emailTracker.CurrentEmail = email;
			uIScreenManager.GoToScreen(UIScreenManager.UIScreens.EmailScreen);
			email.IsEmailRead = true;
		}

		private void GenerateResponses(Email email) {
			EmailInfo[] info = null;


			switch (email.EmailType) {
				case EmailType.Info:
					if (email is InfoEmail) info = GenerateInfoResponses(email as InfoEmail);
					break;
				case EmailType.Inquiry:
					if(email is InquiryEmail) info = GenerateInquiryResponses(email as InquiryEmail);
					break;
				case EmailType.Response:
					if(email is ResponseEmail) info = GenerateResponseResponses(email as ResponseEmail);
					break;
				case EmailType.Spam:
					if(email is SpamEmail) info = GenerateSpamResponses(email as SpamEmail);
					break;
			}

			if(info == null) throw new System.ArgumentException("The email could not be parsed " +
				"as InfoEmail, InquiryEmail, SpamEmail, or ResponseEmail");

			responseController.PopulateResponses(info);
		}

		EmailInfo[] GenerateInfoResponses(InfoEmail email) {
			EmailInfo[] info = new EmailInfo[ResponseController.RESPONSE_AMOUNT];
			for (int i = 0; i < ResponseController.RESPONSE_AMOUNT; ++i) {
				info[i] = responseGenerator.GenerateInfoEmailResponse();
			}
			return info;
		}
		EmailInfo[] GenerateInquiryResponses(InquiryEmail email) {
			int realInfo = Random.Range(0, ResponseController.RESPONSE_AMOUNT);

			EmailInfo[] info = new EmailInfo[ResponseController.RESPONSE_AMOUNT];
			for (int i = 0; i < ResponseController.RESPONSE_AMOUNT; ++i) {
				if(i == realInfo) info[i] = email.InfoToAquire;
				else info[i] = responseGenerator.GenerateInquiryEmailResponse();
			}
			return info;
		}
		EmailInfo[] GenerateSpamResponses(SpamEmail email) {
			EmailInfo[] info = new EmailInfo[ResponseController.RESPONSE_AMOUNT];
			for (int i = 0; i < ResponseController.RESPONSE_AMOUNT; ++i) {
				info[i] = responseGenerator.GenerateSpamEmailResponse();
			}
			return info;
		}
		EmailInfo[] GenerateResponseResponses(ResponseEmail email) {
			EmailInfo[] info = new EmailInfo[ResponseController.RESPONSE_AMOUNT];
			for (int i = 0; i < ResponseController.RESPONSE_AMOUNT; ++i) {
				info[i] = responseGenerator.GenerateResponseEmailResponse();
			}
			return info;
		}

		public void OnTrashPress(Email email) {
			emailTracker.RemoveEmail(email);
		}

		public void OnResponseSent(EmailInfo info) {
			if (emailTracker.CurrentEmail.EmailType == EmailType.Inquiry) {
				if ((emailTracker.CurrentEmail as InquiryEmail).InfoToAquire.Equals(info)) OnCorrectInquiryResponse(); 
				else OnIncorrectResponse(emailTracker.CurrentEmail);
			}
			else if(emailTracker.CurrentEmail.EmailType == EmailType.Info) {
				OnCorrectInfoResponse();
			}

			uIScreenManager.GoToScreen(UIScreenManager.UIScreens.ListScreen);
		}

		public void OnCorrectInfoResponse() => KPIManager.instance.AddCorrectInfoResponse();
		public void OnCorrectInquiryResponse() => KPIManager.instance.AddCorrentInquiryResponse();
		public void OnIncorrectResponse(Email incorrectEmail) {
			KPIManager.instance.AddIncorrectInquiryResponse();
			AddNewResponseEmail(incorrectEmail);
		}
	}
}