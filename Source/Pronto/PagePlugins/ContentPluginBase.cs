﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Pronto.PagePlugins
{
    public abstract class ContentPluginBase : PagePluginBase
    {
        public ContentPluginBase(IWebsiteConfiguration configuration)
        {
            this.configuration = configuration;
        }

        readonly IWebsiteConfiguration configuration;

        public override IEnumerable<XObject> Render(string data)
        {
            var contentString = GetContent(data);
            var content = contentString.ParseXObjects();
            if (IsUserAdmin)
            {
                if (!content.Any()) content = EmptyContentPlaceholder();
                content = WrapWithEditableDiv(content, data);
            }
            return content;
        }

        XElement[] EmptyContentPlaceholder()
        {
            return new[] { new XElement("span", new XAttribute("class", "empty"), configuration.EmptyContentAdminInstruction) };
        }

        protected abstract string GetContent(string contentId);

        protected virtual string EditableCssClass
        {
            get { return "editable"; }
        }

        IEnumerable<XObject> WrapWithEditableDiv(IEnumerable<XObject> content, string contentId)
        {
            return new XObject[] 
            { 
                new XElement("div", 
                    new XAttribute("class", EditableCssClass),
                    new XAttribute("data-content-id", contentId),
                    content
                )
            };
        }

    }
}
