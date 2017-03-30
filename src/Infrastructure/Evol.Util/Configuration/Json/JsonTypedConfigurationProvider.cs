using Evol.Util.Serialization;
using System.IO;

namespace Evol.Util.Configuration.Json
{
    public class JsonTypedConfigurationProvider : FileTypedConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance with the specified source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        public JsonTypedConfigurationProvider(JsonTypedConfigurationSource source) : base(source) { }

        /// <summary>
        /// Loads the JSON data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public override void Load(Stream stream)
        {
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            using (var sReader = new StreamReader(stream))
            {
                var content = sReader.ReadToEnd();
                Data = JsonUtil.Deserialize(content, Source.StrongType);
            }
        }
    }
}
