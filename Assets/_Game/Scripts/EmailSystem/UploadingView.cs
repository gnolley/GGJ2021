using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EmailSystem.UI {
	public class UploadingView : MonoBehaviour {

		[SerializeField] private RectTransform loadingIcon, loadingBar, loadingFill;
		[SerializeField] private float fadeInTime = 0.25f;
		[SerializeField] private CanvasGroup canvasGroup;

		public void StartLoading() {
			gameObject.SetActive(true);
			StopCoroutine(nameof(FadeOut));
			StopCoroutine(nameof(FadeIn));
			StartCoroutine(nameof(FadeIn));
		}

		/// <summary>
		/// Sets the loading bar to a value as a 0-1 percentage
		/// </summary>
		public void UpdateLoadingProgress(float valueAsPercentage) {
			float newWidth = Mathf.Lerp(0f, loadingBar.rect.width, valueAsPercentage);
			loadingFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
		}

		public void EndLoading() {
			StopCoroutine(nameof(FadeIn));
			StopCoroutine(nameof(FadeOut));
			StartCoroutine(nameof(FadeOut));
		}

		private IEnumerator FadeIn() {
			float t = 0;
			while (t < fadeInTime) {
				Fade(t / fadeInTime);
				t += Time.deltaTime;
				yield return null;
			}
			Fade(1f);
		}

		private IEnumerator FadeOut() {
			float t = 0;
			while (t < fadeInTime) {
				Fade(1 - (t / fadeInTime));
				t += Time.deltaTime;
				yield return null;
			}
			Fade(0f);
			gameObject.SetActive(false);
		}

		private void Fade(float t) {
			canvasGroup.alpha = Mathf.Lerp(0, 1, acron0.Easings.QuadraticEaseIn(t));
		}

	}
}
