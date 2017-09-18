using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaxyFarFarAway;
using Microsoft.VisualStudio.DebuggerVisualizers;
using StarWarsDebuggerVisualizers;

[assembly: DebuggerVisualizer(typeof(LifeFormVisualizer), typeof(VisualizerObjectSource), Target = typeof(LifeForm), Description = "Star Wars LifeForm Visualizer")]
[assembly: DebuggerVisualizer(typeof(LightsaberVisualizer), typeof(VisualizerObjectSource), Target = typeof(ForceUserWeapon), Description = "Lightsaber Weapon")]

namespace StarWarsDebuggerVisualizers
{
    public class LightsaberVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var weapon = (ForceUserWeapon)objectProvider.GetObject();

            var window = new Window
            {
                Title = $"{weapon.Color} {weapon.LightsaberType}",
                Width = 400,
                Height = 300
            };

            var colorsMap = new Dictionary<ConsoleColor, string>
            {
                [ConsoleColor.Cyan] = "CyanLightsaber.png",
                [ConsoleColor.Green] = "GreenLightsaber.jpg",
                [ConsoleColor.Magenta] = "PurpleLightsaber.png",
                [ConsoleColor.Red] = "RedLightsaber.png"
            };

            string imageName = null;

            switch (weapon.LightsaberType)
            {
                case LightsaberType.Lightsaber:
                    imageName = colorsMap[weapon.Color];
                    break;
                case LightsaberType.CrossgaurdLightsaber:
                    imageName = "RedCrossgaurdLightsaber.png";
                    break;
                case LightsaberType.DoubleLightsaber:
                    imageName = "RedDoubleLightsaber.png";
                    break;
            }

            if (null != imageName)
            {
                window.Background = new ImageBrush(new BitmapImage(new Uri($@"pack://application:,,,/{typeof(LightsaberVisualizer).Assembly.GetName().Name};component/Images/{imageName}")));
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                window.ShowDialog();
            }
        }
    }

    public class LifeFormVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var lifeForm = (LifeForm)objectProvider.GetObject();

            var window = new Window
            {
                Title = lifeForm.Name,
                Width = 400,
                Height = 300
            };

            var nameDictionary = new Dictionary<string, string>
            {
                ["Yoda"] = "Yoda.jpg",
                ["Obi-Wan Kenobi"] = "ObiWan.jpg",
                ["Luke Skywalker"] = "LukeSkywalker.jpg",
                ["Mace Windu"] = "MaceWindu.jpg",
                ["Darth Vader"] = "DarthVader.png",
                ["Darth Maul"] = "DarthMaul.jpg",
                ["Kylo Ren"] = "KyloRen.jpg"
            };

            if (nameDictionary.ContainsKey(lifeForm.Name))
            {
                var name = nameDictionary[lifeForm.Name];

                window.Background = new ImageBrush(new BitmapImage(new Uri($@"pack://application:,,,/{typeof(LifeFormVisualizer).Assembly.GetName().Name};component/Images/{name}")));
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                window.ShowDialog();
            }
        }
    }
}
