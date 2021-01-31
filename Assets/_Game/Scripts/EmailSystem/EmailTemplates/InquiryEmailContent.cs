using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.Content {
	public class InquiryEmailContent : MonoBehaviour {
		private List<string> InquiryTimeTemplate = new List<string>() {
		"Hey, what time was that thing {0} asked about?",
		"I'm struggling to remember the time of that meeting from {0}, could you ask for me?",
		"Not that I forgot or anything, but just making sure that you know what time {0}'s meeting was?"
	};
		string GetRandomTimeBody() => InquiryTimeTemplate[Random.Range(0, InquiryTimeTemplate.Count)];

		private List<string> InquiryPlaceTemplate = new List<string>() {
		"Did {0} tell you where that meeting was yet? I think I'm in trouble...",
		"I need to know quickly where the meeting was. I'm freaking out dude, it was one of {0}'s ones",
		"The big meeting from {0} is definately at a place. I just can't remember where..."
	};
		string GetRandomPlaceBody() => InquiryPlaceTemplate[Random.Range(0, InquiryPlaceTemplate.Count)];

		private List<string> InquiryReportTemplate = new List<string>() {
		"What was that report called again? The one that {0} is in charge of",
		"I can't seem to remember the rediculous name {0} called that report...",
		"Reports are funning things... Speaking off what was {0}'s report called again?"
	};
		string GetRandomReportBody() => InquiryReportTemplate[Random.Range(0, InquiryReportTemplate.Count)];

		private List<string> TimeSubjectTemplates = new List<string>() {
			"Just wondering about a time...",
			"When was that thing again?",
			"There was a meeting time I think"
		};
		string GetRandomTimeSubject() => TimeSubjectTemplates[Random.Range(0, TimeSubjectTemplates.Count)];

		private List<string> MeetingSubjectTemplates = new List<string>() {
			"Where were we meeting again?",
			"What was that place",
			"Wondering about the meeting spot"
		};
		string GetRandomPlaceSubject() => MeetingSubjectTemplates[Random.Range(0, MeetingSubjectTemplates.Count)];

		private List<string> ReportSubjectTemplates = new List<string>() {
			"Report Name...",
			"What was the report again?",
			"They had a report."
		};
		string GetRandomReportSubject() => ReportSubjectTemplates[Random.Range(0, ReportSubjectTemplates.Count)];

		public InquiryEmail GetInquiryEmail(Author from, InfoEmail basedOn) {
			switch (basedOn.AssociatedInfo.InfoType) {
				case EmailInfo.InfoTypeEnum.Time:
					return new InquiryEmail(from, GetRandomTimeSubject(), string.Format(GetRandomTimeBody(), basedOn.Author.Name), basedOn.AssociatedInfo);
				case EmailInfo.InfoTypeEnum.Place:
					return new InquiryEmail(from, GetRandomPlaceSubject(), string.Format(GetRandomPlaceBody(), basedOn.Author.Name), basedOn.AssociatedInfo);
				case EmailInfo.InfoTypeEnum.Report:
					return new InquiryEmail(from, GetRandomReportSubject(), string.Format(GetRandomReportBody(), basedOn.Author.Name), basedOn.AssociatedInfo);
			}

			Debug.LogError("Email info type broke in getting inquiry email");
			return null;
		}
	}
}
