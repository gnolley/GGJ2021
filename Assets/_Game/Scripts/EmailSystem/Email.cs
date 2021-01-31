namespace EmailSystem {

	public abstract class Email {

		protected Author author;
		protected string subject;
		protected string bodyText;
		protected bool isEmailRead;
		protected EmailType emailType;

		public Email(
				Author author,
				string subject,
				string bodyText,
				EmailType emailType) {
			this.author = author;
			this.subject = subject;
			this.bodyText = bodyText;
			this.emailType = emailType;
		}

		public Author Author {
			get { return author; }
			set { author = value; }
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