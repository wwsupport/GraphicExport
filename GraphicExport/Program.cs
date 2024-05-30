using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchestrA.GRAccess;
using ArchestrA.Visualization.GraphicAccess;

namespace GraphicExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string galaxyName = "";
            string galaxyUser = "";
            string galaxyPass = "";

            string graphicName = "";

            string exportPath = "";

            GRAccessApp grAccess = new GRAccessAppClass();
            IGalaxies galaxies;
            IGraphicAccess4 graphicAccess = (IGraphicAccess4)new ArchestrA.Visualization.GraphicAccess.GraphicAccess();
            IGalaxy gal;

            galaxies = grAccess.QueryGalaxies(System.Environment.MachineName);

            gal = galaxies[galaxyName];

            gal.Login(galaxyUser, galaxyPass);

            try
            {
                IGraphicAccessResult graphicxml = ((IGraphicAccess2)graphicAccess).ExportGraphicToXml(gal, graphicName, exportPath + "\\" + graphicName + ".xml", true);
            }
            catch (Exception ex) 
            {
                gal.Logout();
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Program ended.");
            Console.ReadLine();
        }
    }
}
