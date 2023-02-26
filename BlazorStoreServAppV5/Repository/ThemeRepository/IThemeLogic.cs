using BlazorStoreServAppV5.Models.CssModels;

namespace BlazorStoreServAppV5.Repository.ThemeRepository
{
    public interface IThemeLogic
    {
        public string CurrentTheme { get; set; }
        public List<ThemeModel> InitializeThemes();
    }
}
