using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RolandK.Formats.Gpx.Tests.FileLoad;

[SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
public class GpxFileLoadTests
{
    [Fact]
    public void GpxVersion1_1_CompatibilityMode()
    {
        // Arrange
        using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1.gpx");

        // Act
        var gpxFile = GpxFile.Load(inStream, GpxFileDeserializationMethod.Compatibility);

        // Assert
        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile.Metadata.Name);
        Assert.Single(gpxFile.Tracks);
        Assert.Single(gpxFile.Tracks[0].Segments);
        Assert.Equal(228, gpxFile.Tracks[0].Segments[0].Points.Count);
    }

    [Fact]
    public void GpxVersion1_1_Gpx1_1Mode()
    {
        // Arrange
        using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1.gpx");

        // Act
        var gpxFile = GpxFile.Load(inStream, GpxFileDeserializationMethod.OnlyGpx1_1);

        // Assert
        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile.Metadata.Name);
        Assert.Single(gpxFile.Tracks);
        Assert.Single(gpxFile.Tracks[0].Segments);
        Assert.Equal(228, gpxFile.Tracks[0].Segments[0].Points.Count);
    }

    [Fact]
    public void GpxVersion1_1_on_xml_1_1()
    {
        // Arrange
        using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1_on_xml_1_1.gpx");

        // Act
        var gpxFile = GpxFile.Load(inStream, GpxFileDeserializationMethod.Compatibility);

        // Assert
        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile.Metadata.Name);
        Assert.Single(gpxFile.Tracks);
        Assert.Single(gpxFile.Tracks[0].Segments);
        Assert.Equal(228, gpxFile.Tracks[0].Segments[0].Points.Count);
    }

    [Fact]
    public void GpxVersion1_0()
    {
        // Arrange
        using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_0.gpx");

        // Act
        var gpxFile = GpxFile.Load(inStream, GpxFileDeserializationMethod.Compatibility);

        // Assert
        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile.Metadata.Name);
        Assert.Single(gpxFile.Tracks);
        Assert.Single(gpxFile.Tracks[0].Segments);
        Assert.Equal(228, gpxFile.Tracks[0].Segments[0].Points.Count);
    }

    [Fact]
    public void GpxVersion1_0_SaveAs1_1()
    {
        // Arrange
        using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_0.gpx");

        // Act
        var gpxFile = GpxFile.Load(inStream, GpxFileDeserializationMethod.Compatibility);
        var outStrBuilder = new StringBuilder(33000);
        using (var strWriter = new StringWriter(outStrBuilder))
        {
            GpxFile.Save(gpxFile, strWriter);
        }
        var writtenFile = outStrBuilder.ToString();

        // Assert
        Assert.True(writtenFile.Contains("version=\"1.1\""), "Version attribute");
        Assert.True(writtenFile.Contains("xmlns=\"http://www.topografix.com/GPX/1/1\""), "Default namespace");

        Assert.Equal("1.0", gpxFile.Version);
    }
}