using UnityEngine;
using EmailSystem.UI;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailController : MonoBehaviour {

		[SerializeField] private EmailContentView emailContentView;
		[SerializeField] private EmailTracker emailTracker;
		[SerializeField] private EmailGenerator emailGenerator;
		[SerializeField] private UIScreenManager uIScreenManager;

		[SerializeField] private int startingEmail = 3;

		private void Start() {
			Init();
		}

		private void Init() { 
		
			for(int i=0; i<startingEmail; ++i) {
				emailTracker.AddEmail(emailGenerator.GenerateInfoEmail(), OnEmailPress);
			}

		}

		public void OnEmailPress(Email email) {
			emailContentView.SetContents(email);
			uIScreenManager.GoToScreen(UIScreenManager.UIScreens.EmailScreen);
		}

		public void OnTrashPress(Email email) {
			emailTracker.RemoveEmail(email);
		}

		public void OnResponseSent(EmailInfo info) {
			// TODO: Remember what this does
		}
	}
}