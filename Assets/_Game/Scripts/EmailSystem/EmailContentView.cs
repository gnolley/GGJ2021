using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace EmailSystem.UI {
	public class EmailContentView : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI title, emailAddress, authorName, body;
		[SerializeField] private Image authorPortrait;

		public void SetContents(Email email) {
			title.text = email.Subject;
			emailAddress.text = email.Author.Address;
			authorName.text = email.Author.Name;
			body.text = email.BodyText;
			authorPortrait.sprite = email.Author.Portrait;
		}
	}
}
