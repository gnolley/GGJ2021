using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SignalSystem.UI {

	public class SignalView : MonoBehaviour {
		[SerializeField] private Image signalImage;

		//Signal sprite as all stages empty-full
		[SerializeField] private Sprite signal0, signal1, signal2, signal3;


		/// <summary>
		/// Sets the visual output of the sprite according to 4 levels:
		/// 0: empty
		/// 1-2: bars increasing
		/// 3: full
		/// </summary>
		/// <param name="level"></param>
		public void SetSignalLevel(int level) {
			if (level < 0 || level > 3) {
				Debug.LogError($"Invalid signal level input!");
				return;
			}

			switch (level) {
				case 0:
					SetSignalSprite(signal0);
					break;
				case 1:
					SetSignalSprite(signal1);
					break;
				case 2:
					SetSignalSprite(signal2);
					break;
				case 3:
					SetSignalSprite(signal3);
					break;
			}
		}

		private void SetSignalSprite(Sprite sprite) {
			signalImage.sprite = sprite;
		}
	}
}