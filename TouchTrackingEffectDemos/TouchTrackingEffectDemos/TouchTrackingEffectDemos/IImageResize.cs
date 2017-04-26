using System;

namespace TouchTrackingEffectDemos
{
	public interface IImageResize
	{
		byte[] ResizeImage (byte[] imageData, float width, float height);
	}
}

