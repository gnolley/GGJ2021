using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class EmailInfo : IComparable {
		string infoText;

		public enum InfoTypeEnum { Time, Place, Report};

		private InfoTypeEnum infoType;
		public InfoTypeEnum InfoType {
			get { return infoType; }
			set { infoType = value; }
		}

		public EmailInfo(string infoText, InfoTypeEnum infoType) {
			this.infoText = infoText;
			this.infoType = infoType;
		}

		public string InfoText {
			get { return infoText; }
			set { InfoText = value; }
		}

		public int CompareTo(object obj) {
			if (!(obj is string)) {
				Debug.LogException(new ArgumentException($"Cannot compare EmailInfo to {obj.GetType().ToString()}"));
				return -1;
			}
			else {
				return infoText.CompareTo(obj as string);
			}
		}

		public override bool Equals(object obj) {
			if(obj is string) return infoText.Equals(obj as string);
			else if(obj is EmailInfo) return infoText.Equals((obj as EmailInfo).infoText);

			Debug.LogException(new ArgumentException($"Cannot compare EmailInfo to {obj.GetType().ToString()}"));
			return false;
		}
	}
}
