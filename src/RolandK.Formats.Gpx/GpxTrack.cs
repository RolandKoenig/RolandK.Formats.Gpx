﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace RolandK.Formats.Gpx;

public class GpxTrack : GpxTrackOrRoute
{
    [XmlElement("trkseg")]
    public List<GpxTrackSegment> Segments { get; } = new();

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Track: Name={this.Name}, SegmentCount={this.Segments.Count}";
    }
}