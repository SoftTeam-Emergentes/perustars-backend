using System;

namespace PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects
{
    public class Description
    {
        public string Value { get; set; }

        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Description cannot be empty");
            }

            Value = value;
        }
    }
}
