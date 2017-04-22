using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports.Tests.images
{
    public class Images
    {
        public Images()
        {
            this.Flowers = getImage("360px-Polemonium_reptans_2009.jpg");
            this.Panorama = getImage("An_Teallach_panorama.jpg");
            this.Burger = getImage("Big_Mac_hamburger.jpg");
            this.Cow = getImage("Charolais_cattle");
            this.Hat = getImage("Hat.png");
            this.Logo = getImage("logo.png");
            this.Macaca = getImage("Macaca_nigra_self-portrait_(rotated_and_cropped).jpg");
            this.Space = getImage("NASA_Unveils_Celestial_Fireworks_as_Official_Hubble_25th_Anniversary_Image.jpg");
            this.Fountain = getImage("Pahoeoe_fountain_edit2.jpg");
            this.Penguin = getImage("penguin.jpg");
            this.Coffee = getImage("Roasted_coffee_beans.jpg");
            this.Earth = getImage("The_Earth_seen_from_Apollo_17.jpg");

        }

        public Image Penguin { get; set; }

        public Image Logo { get; set; }

        public Image Hat { get; set; }
        public Image Flowers { get; private set; }
        public Image Panorama { get; private set; }
        public Image Burger { get; private set; }
        public Image Cow { get; private set; }
        public Image Macaca { get; private set; }
        public Image Space { get; private set; }
        public Image Fountain { get; private set; }
        public Image Coffee { get; private set; }
        public Image Earth { get; private set; }

       
        private Image getImage(string imageName)
        {
            var assembly = typeof(Images).Assembly;
            System.IO.Stream file = assembly.GetManifestResourceStream($"Voodoo.Reports.Test.images.{imageName}");
            return  Image.FromStream(file);
        }
    }
}
