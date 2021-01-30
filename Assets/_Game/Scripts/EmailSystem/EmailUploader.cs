﻿using UnityEngine;
using SignalSystem;
using EmailSystem.UI;
using System.Collections;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailUploader : MonoBehaviour {
		[SerializeField] private float uploadRequirement = 1;
		[SerializeField] private UploadingView uploadingView;
		[SerializeField] private EmailController emailController;
		private EmailInfo uploading;

		public float UploadProgress { get; private set; }
		public void ResponseChosen(EmailInfo info) {
			uploading = info;
			StartUpload();
		}

		private void StartUpload() {
			uploadingView.StartLoading();
			StopCoroutine(nameof(UploadRoutine));
			StartCoroutine(nameof(UploadRoutine));
		}
		private void FinishUploading() {
			uploadingView.EndLoading();
		}

		private IEnumerator UploadRoutine() {
			float uploadStatus = 0;
			while (uploadStatus < uploadRequirement) {
				uploadStatus += SignalManager.Instance.CurrentSignal * Time.deltaTime;
				UploadProgress = uploadStatus / uploadRequirement;
				uploadingView.UpdateLoadingProgress(UploadProgress);
				yield return null;
			}

			FinishUploading();
		}
	}
}