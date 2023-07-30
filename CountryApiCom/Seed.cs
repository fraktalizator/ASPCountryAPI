using CityApiCom.Data;
using CityApiCom.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CityApiCom
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext) => this.dataContext = dataContext;
        internal void SeedDataContext()
        {
            /*CountryDTO city = new CountryDTO()
            {
                Name = "Poland",
                Region = "Polska",
                Id = 1,
                Population = 13
            };
            dataContext.Add(city);
            dataContext.SaveChanges();*/
            var pythonSeedCommand = "python .\\seed.py";
            //run_cmd(pythonSeedCommand);
        }

 /*       private void run_cmd(string cmd, string args = "")
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = cmd;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }*/
    }
}
