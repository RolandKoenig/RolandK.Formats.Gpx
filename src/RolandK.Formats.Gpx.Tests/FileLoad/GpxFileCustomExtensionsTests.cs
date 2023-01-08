using System.Xml.Serialization;

namespace RolandK.Formats.Gpx.Tests.FileLoad;

public class GpxFileCustomExtensionsTests
{
    [Fact]
    public async Task AddCustomMetadata()
    {
        // Arrange
        await using var inStream = GpxTestUtilities.ReadFromEmbeddedResource(
            typeof(GpxFileLoadTests),"Test_Gpx1_1.gpx");

        // Act
        GpxFile.RegisterExtensionType(typeof(MyTrackExtension));
        GpxFile.RegisterNamespace("rktest", "http://testing.rolandk.net/");

        var originalGpxFile = await GpxFile.LoadAsync(inStream);
        var originalGpxTrack = originalGpxFile.Tracks[0];

        originalGpxTrack.Extensions ??= new GpxExtensions();
        var myTrackExtension = originalGpxTrack.Extensions.GetOrCreateExtension<MyTrackExtension>();

        myTrackExtension.AlreadyDone = true;

        using var writingMemoryStream = new MemoryStream(1024 * 100);
        await GpxFile.SaveAsync(originalGpxFile, writingMemoryStream);

        using var readingMemoryStream = new MemoryStream(writingMemoryStream.GetBuffer());
        var reloadedFile = await GpxFile.LoadAsync(readingMemoryStream);

        // Assert
        Assert.Single(reloadedFile.Tracks);

        var reloadedTrack = reloadedFile.Tracks[0];
        Assert.NotNull(reloadedTrack.Extensions);

        var reloadedExtension = reloadedTrack.Extensions.TryGetSingleExtension<MyTrackExtension>();
        Assert.NotNull(reloadedExtension);
        Assert.True(reloadedExtension.AlreadyDone);
    }

    [XmlType("MyTrackExtension", Namespace = "http://testing.rolandk.net/")]
    public class MyTrackExtension
    {
        public bool AlreadyDone { get; set; }
    }
}
