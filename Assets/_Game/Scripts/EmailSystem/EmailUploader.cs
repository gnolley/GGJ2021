using UnityEngine;
using SignalSystem;
using EmailSystem.UI;
using System.Collections;
using UnityEngine.Events;

namespace EmailSystem {

	/// <summary>
	///
	/// </summary>
	public class EmailUploader : MonoBehaviour {

		[SerializeField] private float uploadRequirement = 1;
		[SerializeField] private UploadingView uploadingView;
		[SerializeField] private EmailController emailController;
		private EmailInfo uploading;

		private SignalManager signalManager;

		[SerializeField] private UnityEvent OnStartUploadingEvent = new UnityEvent();

		private SignalManager SignalManager {
			get {
				if (signalManager is null) {
					signalManager = FindObjectOfType<SignalManager>();
				}
				return signalManager;
			}
		}

		public float UploadProgress { get; private set; }

		public void ResponseChosen(EmailInfo info) {
			uploading = info;
			StartUpload();
		}

		private void StartUpload() {
			uploadingView.StartLoading();
			OnStartUploadingEvent?.Invoke();
			StopCoroutine(nameof(UploadRoutine));
			StartCoroutine(nameof(UploadRoutine));
		}

		private void FinishUploading() {
			uploadingView.EndLoading();
			emailController.OnResponseSent(uploading);
		}

		private IEnumerator UploadRoutine() {
			float uploadStatus = 0;
			while (uploadStatus < uploadRequirement) {
				uploadStatus += SignalManager.EvaluatedSignalStrength * SignalManager.EvaluatedSignalStrength * Time.deltaTime;
				UploadProgress = uploadStatus / uploadRequirement;
				uploadingView.UpdateLoadingProgress(UploadProgress);
				yield return null;
			}

			FinishUploading();
		}
	}
}