using EmailSystem.Content;
using UnityEngine;

namespace EmailSystem {

	public class EmailGenerator : MonoBehaviour {

		[SerializeField] private Sprite defaultPortrait;
		[SerializeField] private SpamEmailContent spamEmailContent;
		[SerializeField] private InfoEmailContent infoEmailContent;
		[SerializeField] private InquiryEmailContent inquiryEmailContent;
		[SerializeField] private ResponseEmailContent responseEmailContent;

		private void Awake() {
			DEFAULT_AUTHOR = new Author(defaultPortrait, "Jane Doe", "123Evergreen@Terrace.com");
			spamEmailContent.Populate();
		}

		public Email GenerateInfoEmail() {
			return infoEmailContent.GetRandomEmailFromAuthor(DEFAULT_AUTHOR);
		}
		public Email GenerateInquiryEmail(InfoEmail basedOn) {
			return inquiryEmailContent.GetInquiryEmail(DEFAULT_AUTHOR, basedOn);
		}
		public Email GenerateResponseEmail(EmailInfo basedOn) {
			return responseEmailContent.GetResponseEmail(DEFAULT_AUTHOR, basedOn);
		}
		public Email GenerateSpamEmail() {
			return spamEmailContent.GetRandomContent();
		}


		Author DEFAULT_AUTHOR;

		const string DEFAULT_BODY = 
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
			"Praesent eu auctor nisl, vitae molestie nibh. " +
			"Proin feugiat id mi quis laoreet. Ut vitae neque magna. " +
			"Interdum et malesuada fames ac ante orci.";
	}
}