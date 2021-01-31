using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EmailSystem.Content {
    public class InfoEmailContent : MonoBehaviour {
		[SerializeField] private InfoContent infoContent;

		private List<string> MeetingTimeTemplates = new List<string>() {
            "Hi, just reminding you we have a meeting tomorrow at {0} sharp.",
            "Can we discuss the overages at {0} next week sometime?",
            "Are you free to do lunch at {0} on saturday?",
            "Do you think we can do some soul-searching at {0} in a few days?"
        };
        string GetRandomTimeBody() => MeetingTimeTemplates[Random.Range(0, MeetingTimeTemplates.Count)];


        private List<string> MeetingPlaceTemplates = new List<string>() {
            "Hi, just reminding you that the meeting is at {0} tomorrow.",
            "We booked out {0} for a crazy gathering next week...",
            "I would like to see you at {0}. It is urgent.",
        };
        string GetRandomPlaceBody() => MeetingPlaceTemplates[Random.Range(0, MeetingPlaceTemplates.Count)];

        private List<string> ReportTemplates = new List<string>() {
            "The {0} report needs to be in my office on Monday or you're out of here!",
            "Hurry up with that {0} report. I swear you're useless...",
            "The {0} report is getting some fire. Please hurry"
        };
        string GetRandomReportBody() => ReportTemplates[Random.Range(0, ReportTemplates.Count)];


        private List<string> TimeSubjectTemplates = new List<string>() {
            "A meeting time",
            "Be there!",
            "Just so you know..."
        };
        string GetRandomTimeSubject() => TimeSubjectTemplates[Random.Range(0, TimeSubjectTemplates.Count)];

        private List<string> MeetingSubjectTemplates = new List<string>() {
            "A meeting place",
            "The meeting is at...",
            "An update on the meeting place"
        };
        string GetRandomPlaceSubject() => MeetingSubjectTemplates[Random.Range(0, MeetingSubjectTemplates.Count)];

        private List<string> ReportSubjectTemplates = new List<string>() {
            "On that report...",
            "A reminder for the report you're working on...",
            "Report Update"
        };

        string GetRandomReportSubject() => ReportSubjectTemplates[Random.Range(0, ReportSubjectTemplates.Count)];

        public InfoEmail GetRandomEmailFromAuthor(Author author) {
            int template = Random.Range(0, 3);
            EmailInfo info;
            switch (template) {
                case 0:
                    info = infoContent.GetRandomMeetingTimeInfo();
                    return new InfoEmail(author, GetRandomTimeSubject(), string.Format(GetRandomTimeBody(), info.InfoText), info);
                case 1:
                    info = infoContent.GetRandomMeetingPlaceInfo();
                    return new InfoEmail(author, GetRandomPlaceSubject(), string.Format(GetRandomPlaceBody(), info.InfoText), info);
                case 2:
                    info = infoContent.GetRandomReportInfo();
                    return new InfoEmail(author, GetRandomReportSubject(), string.Format(GetRandomReportBody(), info.InfoText), info);
            }

            Debug.LogError("Random range broke in getting random info email");
            return null;
        }
    }
}
