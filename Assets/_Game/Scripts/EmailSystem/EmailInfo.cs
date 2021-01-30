using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem {
	public class EmailInfo : IComparable {
		string infoText;

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
			if (!(obj is string)) {
				Debug.LogException(new ArgumentException($"Cannot compare EmailInfo to {obj.GetType().ToString()}"));
				return false;
			}
			else {
				return infoText.Equals(obj as string);
			}
		}
	}
}
