using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports.Tests.Images
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

        public byte[] Penguin { get; set; }

        public byte[] Logo { get; set; }

        public byte[] Hat { get; set; }
        public byte[] Flowers { get; private set; }
        public byte[] Panorama { get; private set; }
        public byte[] Burger { get; private set; }
        public byte[] Cow { get; private set; }
        public byte[] Macaca { get; private set; }
        public byte[] Space { get; private set; }
        public byte[] Fountain { get; private set; }
        public byte[] Coffee { get; private set; }
        public byte[] Earth { get; private set; }


        private byte[] getImage(string imageName)
        {
            var asm = this.GetType().Assembly.ToString().Split(',').First();
            imageName = $"{asm}.Images.{imageName}";
            var assembly = typeof(Images).Assembly;
            using (var resFilestream = assembly.GetManifestResourceStream(imageName))
            {
                if (resFilestream == null) return null;
                byte[] bytes = new byte[resFilestream.Length];
                resFilestream.Read(bytes, 0, bytes.Length);
                return bytes;
            }


            //System.IO.Stream file = assembly.GetManifestResourceStream($"Voodoo.Reports.Test.images.{imageName}");
            //return  file;
        }
    }
}