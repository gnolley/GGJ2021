using UnityEngine;

namespace EmailSystem {

	public class EmailGenerator : MonoBehaviour {

		[SerializeField] private Sprite defaultPortrait;
		private void Awake() {
			DEFAULT_AUTHOR = new Author(defaultPortrait, "Jane Doe", "123Evergreen@Terrace.com");
		}

		public Email GenerateInfoEmail() { 
			return new InfoEmail(DEFAULT_AUTHOR, "Info Email", "Some more Info", DEFAULT_BODY, new EmailInfo("10:30")); 
		}
		public Email GenerateInquiryEmail(EmailInfo basedOn) {
			return new InquiryEmail(DEFAULT_AUTHOR, "Inquiry Email", "Some Inquiry Please", DEFAULT_BODY, basedOn);
		}
		public Email GenerateResponseEmail(Email basedOn) {
			return new ResponseEmail(DEFAULT_AUTHOR, "Response Email", "You Suck!", DEFAULT_BODY, basedOn);
		}
		public Email GenerateSpamEmail() {
			return new SpamEmail(DEFAULT_AUTHOR, "Spam Email", "Give me MoneY!", DEFAULT_BODY);
		}


		Author DEFAULT_AUTHOR;

		const string DEFAULT_BODY = 
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
			"Praesent eu auctor nisl, vitae molestie nibh. " +
			"Proin feugiat id mi quis laoreet. Ut vitae neque magna. " +
			"Interdum et malesuada fames ac ante orci.";
	}
}