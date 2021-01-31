using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.Content {
	public class ResponseEmailContent : MonoBehaviour {
		private List<string> InquiryTimeTemplate = new List<string>() {
		"Hey! You told me the wrong time dumbass, the meeting wasn't at {0}",
		"I can't believe you screwed me over again... I showed up at {0} like an ass, an hour late.",
		"When will you get anything right? The time you told me was WRONG! It wasn't {0}"
	};
		string GetRandomTimeBody() => InquiryTimeTemplate[Random.Range(0, InquiryTimeTemplate.Count)];

		private List<string> InquiryPlaceTemplate = new List<string>() {
		"So guess what? I showed up at {0} and nobody was there. What the heck dude?",
		"Well... nobody was at {0} when I got there. What a waste of time.",
		"You told me the wrong place! It wasn't at {0}"
	};
		string GetRandomPlaceBody() => InquiryPlaceTemplate[Random.Range(0, InquiryPlaceTemplate.Count)];

		private List<string> InquiryReportTemplate = new List<string>() {
		"Nice work... I printed out 500 fliers for {0}, and that wasn't even the report!",
		"Well I used the report name you told me in a meeting and got reemed out! It deffinately wasn't {0}",
		"What's your problem? Telling me it was {0} when is wasn't..."
	};
		string GetRandomReportBody() => InquiryReportTemplate[Random.Range(0, InquiryReportTemplate.Count)];

		private List<string> TimeSubjectTemplates = new List<string>() {
			"Really man?",
			"Did you have to tell me the wrong time?",
			"Wrong AGAIN"
		};
		string GetRandomTimeSubject() => TimeSubjectTemplates[Random.Range(0, TimeSubjectTemplates.Count)];

		private List<string> MeetingSubjectTemplates = new List<string>() {
			"You gave me the wrong place!",
			"That was the wrong spot!",
			"Why would you send me all the way out there?"
		};
		string GetRandomPlaceSubject() => MeetingSubjectTemplates[Random.Range(0, MeetingSubjectTemplates.Count)];

		private List<string> ReportSubjectTemplates = new List<string>() {
			"You screwed up the report name.",
			"WRONG REPORT NAME",
			"The report name was wrong"
		};
		string GetRandomReportSubject() => ReportSubjectTemplates[Random.Range(0, ReportSubjectTemplates.Count)];


		public ResponseEmail GetResponseEmail(Author from, EmailInfo basedOn) {
			switch (basedOn.InfoType) {
				case EmailInfo.InfoTypeEnum.Time:
					return new ResponseEmail(from, GetRandomTimeSubject(), string.Format(GetRandomTimeBody(), basedOn.InfoText), basedOn);
				case EmailInfo.InfoTypeEnum.Place:
					return new ResponseEmail(from, GetRandomPlaceSubject(), string.Format(GetRandomPlaceBody(), basedOn.InfoText), basedOn);
				case EmailInfo.InfoTypeEnum.Report:
					return new ResponseEmail(from, GetRandomReportSubject(), string.Format(GetRandomReportBody(), basedOn.InfoText), basedOn);
			}

			Debug.LogError("Email info type broke in getting response email");
			return null;
		}
	}
}
