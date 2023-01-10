# RolandK.Formats.Gpx <img src="assets/Logo_128.png" width="32" />
## Common Information
A .NET Standard library for reading and writing GPX (GPS Exchange Format) files.
This library was build for my [GpxViewer](https://github.com/RolandKoenig/GpxViewer) project. It is based
on the System.Xml.Serialization.XmlSerializer class and therefore available for .NET Framework and .NET Core projects.

## Feature overview
- Full document model for gpx files
- Load gpx files
- Write gpx files
- Add custom xml extensions to gpx files
- Don't lose other custom xml extensions information after loading and saving gpx files

## Build
[![Continuous integration](https://github.com/RolandKoenig/RolandK.Formats.Gpx/actions/workflows/continuous-integration.yml/badge.svg)](https://github.com/RolandKoenig/RolandK.Formats.Gpx/actions/workflows/continuous-integration.yml)

## Nuget
| Package             | Downloads
|---------------------|---------------------------------------------------------------------------------------------------------------------|
| RolandK.Formats.Gpx | [![Nuget](https://img.shields.io/nuget/dt/RolandK.Formats.Gpx)](https://www.nuget.org/packages/RolandK.Formats.Gpx) |

## Samples
### Load GPX file
Load file file (here Kösseine.gpx) and get total count of tracks, routes and waypoints in the file
```csharp
var gpxFile = await GpxFile.LoadAsync("Kösseine.gpx");

var countTracks = gpxFile.Tracks.Count;
var countRoutes = gpxFile.Routes.Count;
var countWaypoints = gpxFile.Waypoints.Count;
```

### Save GPX file
Save a previously loaded / created / modified file
```csharp
await GpxFile.SaveAsync(gpxFile, "MyFile.gpx");
```

### Add custom xml extension 
Your have to define your own xml extension types and give them a namespace
```csharp
[XmlType("MyTrackExtension", Namespace = "http://testing.rolandk.net/")]
public class MyTrackExtension
{
    public bool AlreadyDone { get; set; } = false;
}
```

Then you have to register these xml extension types and their namespaces to GpxFile. 
You should do this somewhere in your startup code of your application.
```csharp
// You have to register your own xml extension types 
GpxFile.RegisterExtensionType(typeof(MyTrackExtension));
GpxFile.RegisterNamespace("rktest", "http://testing.rolandk.net/");
```

Now you can access these xml extensions from c# code
```csharp
var gpxFile = await GpxFile.LoadAsync(inStream);
var gpxTrack = gpxFile.Tracks[0];

gpxTrack.Extensions ??= new GpxExtensions();
var myTrackExtension = gpxTrack.Extensions.GetOrCreateExtension<MyTrackExtension>();

myTrackExtension.AlreadyDone = true; // This property comes from our own xml extension
```