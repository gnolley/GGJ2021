using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace EmailSystem.UI {
	public class EmailNotificationView : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI title, subject;
		[SerializeField] private Image portait;
		[SerializeField] private Color readColor;

		Email associatedEmail;
		Action<Email> onPressCallback;
		Action<Email> onTrashCallback;

		public void Populate(Email email, Action<Email> onPressCallback, Action<Email> onTrashCallback) {
			title.text = email.Author.Name;
			subject.text = email.Subject;
			portait.sprite = email.Author.Portrait;
			associatedEmail = email;
			this.onPressCallback = onPressCallback;
			this.onTrashCallback = onTrashCallback;
		}

		public Email GetAssociatedEmail() => associatedEmail;

		public void DeleteNotification() {
			Destroy(gameObject);
		}

		private void OnEnable() {
			if (associatedEmail != null) {
				if (associatedEmail.IsEmailRead)
					SetAsRead();
			}
		}

		public void SetAsRead() {
			title.color = readColor;
			subject.color = readColor;
		}

		public void OnPress() {
			if(onPressCallback != null) onPressCallback.Invoke(associatedEmail);
		}

		public void OnTrashPress() {
			if(onTrashCallback != null) onTrashCallback.Invoke(associatedEmail);
		}
	}
}
