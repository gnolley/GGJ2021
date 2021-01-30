using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmailSystem.UI {
	public class EmailNotificationView : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI title, subject;
		[SerializeField] private Image portait;

		public void Populate(Email email) {
			title.text = email.Title;
			subject.text = email.Subject;
			portait.sprite = email.Author.Portrait;
		}

		public void SetAsRead() {

		}
	}
}
