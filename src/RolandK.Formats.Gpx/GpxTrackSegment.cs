using System.Collections.Generic;
using System.Xml.Serialization;

namespace RolandK.Formats.Gpx;

public class GpxTrackSegment
{
    [XmlElement("trkpt")]
    public List<GpxWaypoint> Points { get; } = new();

    [XmlElement("extensions")]
    public GpxExtensions? Extensions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"TrackSegment: PointCount={this.Points.Count}";
    }
}