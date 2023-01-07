using System.Xml.Serialization;

namespace RolandK.Formats.Gpx.Metadata;

public class GpxEMail
{
    [XmlAttribute("id")]
    public string ID { get; set; } = string.Empty;

    [XmlAttribute("domain")]
    public string Domain { get; set; } = string.Empty;

    /// <inheritdoc />
    public override string ToString()
    {
        return $"EMail: ID={this.ID}, Domain={this.Domain}";
    }
}