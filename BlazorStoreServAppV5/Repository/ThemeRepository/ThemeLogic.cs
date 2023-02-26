using BlazorStoreServAppV5.Models.CssModels;

namespace BlazorStoreServAppV5.Repository.ThemeRepository
{
    public class ThemeLogic : IThemeLogic
    {
        public string CurrentTheme { get; set; } = "colorBlack";
        private List<ThemeModel> ListOfThemes = new();
        public List<ThemeModel> InitializeThemes()
        {
            if(ListOfThemes.Count<3){
            ListOfThemes.Add(new ThemeModel() { Theme = "dark", Value = "colorBlack" });
            ListOfThemes.Add(new ThemeModel() { Theme = "light", Value = "colorWhite" });
            ListOfThemes.Add(new ThemeModel() { Theme = "green", Value = "colorGreen" });
            }
            return ListOfThemes;
        }
    }
}
