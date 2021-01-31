using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class ResponseGenerator : MonoBehaviour {
		[SerializeField] private InfoContent infoContent;

		public EmailInfo GenerateInfoEmailResponse() {
			return infoContent.GetRandomInfoResponse();
		}

		public EmailInfo GenerateInquiryEmailResponse(EmailInfo.InfoTypeEnum type) {
			switch (type) {
				case EmailInfo.InfoTypeEnum.Time:
					return infoContent.GetRandomMeetingTimeInfo();
				case EmailInfo.InfoTypeEnum.Place:
					return infoContent.GetRandomMeetingPlaceInfo();
				case EmailInfo.InfoTypeEnum.Report:
					return infoContent.GetRandomReportInfo();
			}
			return new EmailInfo("Inquiry Response", type);
		}

		public EmailInfo GenerateSpamEmailResponse() {
			return infoContent.GetRandomSpamResponse();
		}
		public EmailInfo GenerateResponseEmailResponse() {
			return infoContent.GetRandomAngryResponse();
		}
	}
}
