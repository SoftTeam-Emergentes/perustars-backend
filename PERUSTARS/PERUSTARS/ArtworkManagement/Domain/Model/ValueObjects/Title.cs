using System;

namespace PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects
{
    public class Title
    {
        public string Value { get; set; }

        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            Value = value;
        }
    }
}
