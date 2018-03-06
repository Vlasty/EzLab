using System;
using System.Collections.Generic;
using PoeHUD.Framework.Helpers;
using PoeHUD.Models;
using PoeHUD.Plugins;
using SharpDX;
using SharpDX.Direct3D9;

namespace EzLab
{
    public class EzLab : BaseSettingsPlugin<EzLabSettings>
    {
        public const string Version = "1.1";
        public static int Selected;

        public static string[] SettingName =
        {
                "EzLab",
        };

        private HashSet<EntityWrapper> _entityCollection;

        public string CustomImagePath;

        public string PoeHudImageLocation;

        public EzLab() => PluginName = "EzLab";

        public override void Initialise()
        {
            _entityCollection = new HashSet<EntityWrapper>();
            CustomImagePath = PluginDirectory + @"\images\";
            PoeHudImageLocation = PluginDirectory + @"\..\..\textures\";
        }

        public override void EntityAdded(EntityWrapper entity) { _entityCollection.Add(entity); }

        public override void EntityRemoved(EntityWrapper entity) { _entityCollection.Remove(entity); }

        private void RenderTextLabel(ColorBGRA color, string text, string path)
        {
            try
            {
                var camera = GameController.Game.IngameState.Camera;

                var baseY = 0;
                if (color == (ColorBGRA)Color.Yellow)
                {
                    baseY = 20;
                }
                else if (color == (ColorBGRA)Color.Red)
                {
                    baseY = 40;
                }

                foreach (var entity in _entityCollection)
                    if (entity.Path.ToLower().Contains(path.ToLower()))
                    {
                        var chestScreenCoords = camera.WorldToScreen(entity.Pos.Translate(0, baseY, 0), entity);
                        if (chestScreenCoords == new Vector2()) continue;
                        var iconRect = new Vector2(chestScreenCoords.X, chestScreenCoords.Y);
                        Graphics.DrawText(text, 20, iconRect, color, FontDrawFlags.Center);
                    }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public override void Render()
        {
            base.Render();

            RenderTextLabel(Color.Gray, "Low currency 1", "IzaroChest1");
            RenderTextLabel(Color.Yellow, "Mid currency 2", "IzaroChest2");
            RenderTextLabel(Color.Gray, "Low currency 3", "IzaroChest3");
            RenderTextLabel(Color.Gray, "Izaro Chest 4", "IzaroChest4");
            RenderTextLabel(Color.Yellow, "qCurrency 5", "IzaroChest5");
            RenderTextLabel(Color.Yellow, "qCurrency 6", "IzaroChest6");
            RenderTextLabel(Color.Gray, "jewelry 7", "IzaroChest7");
            RenderTextLabel(Color.Gray, "jewelry 8", "IzaroChest8");
            RenderTextLabel(Color.Gray, "trash 9", "IzaroChest9");
            RenderTextLabel(Color.Gray, "trash 10", "IzaroChest10");

            RenderTextLabel(Color.Gray, "weapon trash 11", "IzaroChest11");
            RenderTextLabel(Color.Gray, "Izaro Chest 12", "IzaroChest12");
            RenderTextLabel(Color.Red, "Diviner 13", "IzaroChest13");
            RenderTextLabel(Color.Gray, "trash 14", "IzaroChest14");
            RenderTextLabel(Color.Gray, "Generic 15", "IzaroChest15");
            RenderTextLabel(Color.Gray, "Generic 16", "IzaroChest16");
            RenderTextLabel(Color.Gray, "armour+weapon 17", "IzaroChest17");
            RenderTextLabel(Color.Red, "2 keys + uniq 18", "IzaroChest18");
            RenderTextLabel(Color.Red, "Maps 19", "IzaroChest19");
            RenderTextLabel(Color.Gray, "Izaro Chest 20", "IzaroChest20");

            RenderTextLabel(Color.Red, "84ilvl armour 21", "IzaroChest21");
            RenderTextLabel(Color.Red, "Maps 22", "IzaroChest22");
            RenderTextLabel(Color.Red, "Corrupted 2 midnights 23", "IzaroChest23");
            RenderTextLabel(Color.Yellow, "Gems 24", "IzaroChest24");
            RenderTextLabel(Color.Red, "High Currency 25", "IzaroChest25");
            RenderTextLabel(Color.Yellow, "Mid currency 26", "IzaroChest26");
            RenderTextLabel(Color.Gray, "Low currency 27", "IzaroChest27");
            RenderTextLabel(Color.Yellow, "qCurrency 28", "IzaroChest28");
            RenderTextLabel(Color.Gray, "Jewelry 29", "IzaroChest29");
            RenderTextLabel(Color.Gray, "Jewelry 30", "IzaroChest30");

            RenderTextLabel(Color.Gray, "Armour trash 31", "IzaroChest31");
            RenderTextLabel(Color.Red, "Armour ~6S 32", "IzaroChest32");
            RenderTextLabel(Color.Gray, "Weapons trash 33", "IzaroChest33");
            RenderTextLabel(Color.Gray, "Generic 34", "IzaroChest34");
            RenderTextLabel(Color.Yellow, "3x Uniques 35", "IzaroChest35");
            RenderTextLabel(Color.Red, "2 keys + uniq 36", "IzaroChest36");
            RenderTextLabel(Color.Yellow, "Corrupted 0 atziri 37", "IzaroChest37");
            RenderTextLabel(Color.Yellow, "Gems 38", "IzaroChest38");
            RenderTextLabel(Color.Red, "Offering to the goddes 39", "IzaroChest39");
            RenderTextLabel(Color.Yellow, "84ilvl weapons 40", "IzaroChest40");
            RenderTextLabel(Color.Yellow, "Gems 41", "IzaroChest41");
        }
    }

    internal static class ExtensionMethod
    {
        public static bool InRange(this int current, int range1, int range2) => current >= range1 && current <= range2;
    }
}