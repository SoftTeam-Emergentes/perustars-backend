using System;

namespace PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects
{
    public class ArtworkContent
    {
        public byte[] Content { get; set; }
        public string Format { get; set; }

        public ArtworkContent(byte[] content, string format)
        {
            Content = content;
            Format = format;
        }
    }
}
