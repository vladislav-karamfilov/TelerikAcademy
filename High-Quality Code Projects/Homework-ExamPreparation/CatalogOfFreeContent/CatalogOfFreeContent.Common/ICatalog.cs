namespace CatalogOfFreeContent.Common
{
    using System.Collections.Generic;

    public interface ICatalog
    {
        /// <summary>
        /// Adds the specified content to the catalog.
        /// </summary>
        /// <param name="content">The content to be added.</param>
        void Add(IContent content);

        /// <summary>
        /// Gets an enumerable collection of content items with specified title.
        /// The order of the elements is alphabetical according to their 
        /// ToString() representation.
        /// </summary>
        /// <param name="title">The title of content items to get.</param>
        /// <param name="numberOfElementsToList">The number of elements to list.</param>
        /// <returns>Enumerable collection of content items with specified title.</returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfElementsToList);

        /// <summary>
        /// Updates the content item URL.
        /// </summary>
        /// <param name="oldUrl">The old URL.</param>
        /// <param name="newUrl">The new URL.</param>
        /// <returns>Number of updated elements.</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
