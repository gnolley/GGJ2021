namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public abstract class Email {

		private Author author;
		private string title;
		private string subject;
		private string bodyText;
		private bool isEmailRead;
		private EmailType emailType;
		private EmailInfo emailInfo;



		public EmailInfo MyProperty {
			get { return emailInfo; }
			set { emailInfo = value; }
		}


		public Author Author {
			get { return author; }
			set { author = value; }
		}

		public string Title {
			get { return title; }
			set { title = value; }
		}

		public string Subject {
			get { return subject; }
			set { subject = value; }
		}

		public string BodyText {
			get { return bodyText; }
			set { bodyText = value; }
		}

		public bool IsEmailRead {
			get { return isEmailRead; }
			set { isEmailRead = value; }
		}

		public EmailType EmailType {
			get { return emailType; }
			set { emailType = value; }
		}
	}
}