using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class InfoContent : MonoBehaviour {
		private List<EmailInfo> MeetingTimeInfo = new List<EmailInfo>() {
			new EmailInfo("12:30", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("1:00 pm", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("6:00 am", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("2:30", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("4:39", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("12:00 am", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("5:00 pm", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("1:19", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("4:30", EmailInfo.InfoTypeEnum.Time),
			new EmailInfo("7:12", EmailInfo.InfoTypeEnum.Time)
		};

		private List<EmailInfo> MeetingPlaceInfo = new List<EmailInfo>() {
			new EmailInfo("Jerarah", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Saskatoon", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The corner office", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The Coroner's office", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Jezzabell's Church", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Apartment AB", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Office 34", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The Cricket Ground", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Room No. 6", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The Tippler's Tap", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The Track", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The Auditorium", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Crankfest", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("The 99th Precict", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Office 8", EmailInfo.InfoTypeEnum.Place)
		};

		private List<EmailInfo> ReportInfo = new List<EmailInfo>() {
			new EmailInfo("The Ninja Report", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Contract and Equity", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Minority", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("Creepy", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Plant Consumption", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Book Burning", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Gas Trail", EmailInfo.InfoTypeEnum.Report),
			new EmailInfo("The Sadle Blaze", EmailInfo.InfoTypeEnum.Report)
		};


		private List<EmailInfo> infoResponses = new List<EmailInfo>() {
			new EmailInfo("Got it", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Sure thing boss", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Alrighty", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Ain't that the truth", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Okay", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("OK", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("=)", EmailInfo.InfoTypeEnum.Place)
		};
		public EmailInfo GetRandomInfoResponse() {
			return infoResponses[Random.Range(0, infoResponses.Count)];
		}

		private List<EmailInfo> spamResponses = new List<EmailInfo>() {
			new EmailInfo("I'm in!", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("That sounds great!", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("How could that go wrong?", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Too easy", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Here we go", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Go away", EmailInfo.InfoTypeEnum.Place),
		};
		public EmailInfo GetRandomSpamResponse() {
			return spamResponses[Random.Range(0, spamResponses.Count)];
		}

		private List<EmailInfo> angryResponses = new List<EmailInfo>() {
			new EmailInfo("Calm down", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("I tried!", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Get lost.", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Piss off.", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Thanks, I hate it.", EmailInfo.InfoTypeEnum.Place),
			new EmailInfo("Try Again Later", EmailInfo.InfoTypeEnum.Place),
		};
		public EmailInfo GetRandomAngryResponse() {
			return angryResponses[Random.Range(0, angryResponses.Count)];
		}


		public EmailInfo GetRandomMeetingTimeInfo() {
			return MeetingTimeInfo[Random.Range(0, MeetingTimeInfo.Count)];
		}

		public EmailInfo GetRandomMeetingPlaceInfo() {
			return MeetingPlaceInfo[Random.Range(0, MeetingPlaceInfo.Count)];
		}

		public EmailInfo GetRandomReportInfo() {
			return ReportInfo[Random.Range(0, ReportInfo.Count)];
		}
	}
}