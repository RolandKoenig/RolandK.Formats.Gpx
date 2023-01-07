namespace RolandK.Formats.Gpx.Tests;

internal static class GpxTestUtilities
{
    public static Stream ReadFromEmbeddedResource(Type testType, string resourceFileName)
    {
        var embeddedResourceName =
            $"{testType.Namespace}.{resourceFileName}";

        var result = testType.Assembly.GetManifestResourceStream(embeddedResourceName);
        if (result == null)
        {
            throw new FileNotFoundException("Unable to find embedded resource", embeddedResourceName);
        }

        return result;
    }
}
