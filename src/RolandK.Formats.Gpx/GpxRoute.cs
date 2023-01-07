using System.Collections.Generic;
using System.Xml.Serialization;

namespace RolandK.Formats.Gpx;

public class GpxRoute : GpxTrackOrRoute
{
    [XmlElement("rtept")]
    public List<GpxWaypoint> RoutePoints { get; } = new();

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Route: Name={this.Name}, PointCount={this.RoutePoints.Count}";
    }
}