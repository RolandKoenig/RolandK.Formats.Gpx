﻿using System.Text;

namespace RolandK.Formats.Gpx.Tests.FileLoad;

public class GpxFileLoadAsyncTests
{
    [Fact]
    public async Task GpxVersion1_1_CompatibilityMode()
    {
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1.gpx");

        var gpxFile = await GpxFile.LoadAsync(inStream, GpxFileDeserializationMethod.Compatibility);

        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile!.Metadata!.Name);
        Assert.Single(gpxFile.Tracks);
    }

    [Fact]
    public async Task GpxVersion1_1_Gpx1_1Mode()
    {
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1.gpx");

        var gpxFile = await GpxFile.LoadAsync(inStream, GpxFileDeserializationMethod.OnlyGpx1_1);

        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile!.Metadata!.Name);
        Assert.Single(gpxFile.Tracks);
    }

    [Fact]
    public async Task GpxVersion1_1_on_xml_1_1()
    {
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1_on_xml_1_1.gpx");

        var gpxFile = await GpxFile.LoadAsync(inStream, GpxFileDeserializationMethod.Compatibility);

        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile!.Metadata!.Name);
        Assert.Single(gpxFile.Tracks);
    }

    [Fact]
    public async Task GpxVersion1_0()
    {
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_0.gpx");

        var gpxFile = await GpxFile.LoadAsync(inStream, GpxFileDeserializationMethod.Compatibility);

        Assert.NotNull(gpxFile);
        Assert.NotNull(gpxFile.Metadata);
        Assert.Equal("Kösseine", gpxFile!.Metadata!.Name);
        Assert.Single(gpxFile.Tracks);
    }

    [Fact]
    public async Task GpxVersion1_0_SaveAs1_1()
    {
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_0.gpx");

        var gpxFile = await GpxFile.LoadAsync(inStream, GpxFileDeserializationMethod.Compatibility);
        var outStrBuilder = new StringBuilder(33000);
        using (var strWriter = new StringWriter(outStrBuilder))
        {
            await GpxFile.SaveAsync(gpxFile, strWriter);
        }
        var writtenFile = outStrBuilder.ToString();

        // Check output
        Assert.True(writtenFile.Contains("version=\"1.1\""), "Version attribute");
        Assert.True(writtenFile.Contains("xmlns=\"http://www.topografix.com/GPX/1/1\""), "Default namespace");

        // Check original data
        Assert.Equal("1.0", gpxFile.Version);
    }
}