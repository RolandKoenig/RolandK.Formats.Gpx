using System.Xml.Serialization;

namespace RolandK.Formats.Gpx.Metadata;

public class GpxBounds
{
    [XmlAttribute("minlat")]
    public double MinLatitude { get; set; }

    [XmlAttribute("minlon")]
    public double MinLongitude { get; set; }

    [XmlAttribute("maxlat")]
    public double MaxLatitude { get; set; }

    [XmlAttribute("maxlon")]
    public double MaxLongitude { get; set; }
}