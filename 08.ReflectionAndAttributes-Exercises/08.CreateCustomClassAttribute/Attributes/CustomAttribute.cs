namespace CreateCustomClassAttribute.Attributes
{
    using System;
    using System.Collections.Generic;

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>();
            foreach (string reviewer in reviewers)
            {
                this.Reviewers.Add(reviewer);
            }
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public IList<string> Reviewers { get; }
    }
}