using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Pronto.PagePlugins
{
    public class FavIconPlugin : PagePluginBase
    {
        public override IEnumerable<XObject> Render(string data)
        {
            yield return new XElement("link",
                new XAttribute("rel", "shortcut icon"),
                new XAttribute("type", "image/vnd.microsoft.icon"),
                new XAttribute("href", UrlBase + "favicon.ico"));
        }
    }
}
