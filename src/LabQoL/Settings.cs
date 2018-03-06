using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;

namespace EzLab
{
    public class EzLabSettings : SettingsBase
    {
        public EzLabSettings()
        {
            Enable = true;
        }

        [Menu("Version " + EzLab.Version)]
        public EmptyNode VersionNode { get; set; }
    }
}