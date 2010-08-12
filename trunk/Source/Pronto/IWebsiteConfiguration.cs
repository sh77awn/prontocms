namespace Pronto
{
    public interface IWebsiteConfiguration
    {
        string WebsiteXmlFilename { get; }
        string ThemeName { get; }
        string TemplateDirectory { get; }
        string EmptyContentAdminInstruction { get; }
    }
}