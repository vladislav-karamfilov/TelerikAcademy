namespace TicketingSystem.Common.DataAnnotations
{
    using System;
    using System.Web.Mvc;

    public class PlaceholderAttribute : Attribute, IMetadataAware
    {
        private readonly string placeholder;

        public PlaceholderAttribute(string placeholder)
        {
            this.placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = this.placeholder;
        }
    }
}
