using System;

namespace RolandK.Formats.Gpx;

public class GpxFileException : Exception
{
    public GpxFileException(string message)
        : base(message)
    {
    }

    public GpxFileException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}