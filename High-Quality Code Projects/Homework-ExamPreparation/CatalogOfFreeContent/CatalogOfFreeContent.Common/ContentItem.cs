namespace CatalogOfFreeContent.Common
{
    using System;

    public class ContentItem : IComparable, IContent
    {
        public ContentItem(ContentType type, string[] contentItemParams)
        {
            this.Type = type;
            this.Title = contentItemParams[(int)ContentInfoType.Title];
            this.Author = contentItemParams[(int)ContentInfoType.Author];
            this.Size = long.Parse(contentItemParams[(int)ContentInfoType.Size]);
            this.Url = contentItemParams[(int)ContentInfoType.Url];

            this.TextRepresentation = this.ToString(); // For performance improvement
        }

        public ContentType Type { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                if (this == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResult;
            }
            else
            {
                throw new ArgumentException("Provided object is not a ContentItem!", "obj");
            }
        }

        public override string ToString()
        {
            string output = string.Format(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type.ToString(), 
                this.Title, 
                this.Author, 
                this.Size, 
                this.Url);

            return output;
        }
    }
}
