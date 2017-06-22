using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.VR.WSA.WebCam;

class ExperienceManager : MonoBehaviour
{
	private PhotoCapture captureDevice = null;

	private void Start()
	{
		PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
	}

	private void OnDestroy()
	{
		captureDevice.Dispose();
	}

	public void CaptureImageAndProduceTags()
	{
		if (captureDevice != null)
		{
			Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

			CameraParameters c = new CameraParameters()
			{
				hologramOpacity = 0.0f,
				cameraResolutionWidth = cameraResolution.width,
				cameraResolutionHeight = cameraResolution.height,
				pixelFormat = CapturePixelFormat.JPEG
			};
			captureDevice.StartPhotoModeAsync(c, OnPhotoModeStarted);
		}
	}

	private void OnPhotoCaptureCreated(PhotoCapture captureDevice)
	{
		this.captureDevice = captureDevice;
	}

	private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
	{
		if (result.success)
		{
			captureDevice.TakePhotoAsync(OnPhotoTaken);
		}
	}

	private void OnPhotoTaken(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photo)
	{
		if (result.success)
		{
			List<byte> imageBufferList = new List<byte>();
			// Copy the raw IMFMediaBuffer data into our empty byte list.
			photo.CopyRawImageDataIntoBuffer(imageBufferList);

			// analyze
			this.AnalyzeImage(imageBufferList.ToArray());
		}
		else
		{
			captureDevice.StopPhotoModeAsync((PhotoCapture.PhotoCaptureResult res) => { });
		}
	}

	private string AnalyzeImage(byte[] imageData)
	{
		// should be able to take imageData and mime: image/jpeg to analyze api
		throw new NotImplementedException();
	}

	private List<string> ParseTags(string jsonResult)
	{
		throw new NotImplementedException();
	}

	private string TranslateTag(string tag, string language)
	{
		throw new NotImplementedException();
	}
}
