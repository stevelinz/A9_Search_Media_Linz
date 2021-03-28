using System;
using System.Collections.Generic;
using System.IO;

namespace MediaProject
{
    public class ShowProcess : Media
    {
     public List<Show> Shows { get; set; }

     
     
 
        public ShowProcess()
        {
        
            int hitCount = 0;
         
            Shows = new List<Show>();
            Show show = new Show();
            StreamReader sr = new StreamReader("shows.csv");

          
        
            
            string searchItem = File.ReadAllText("search.tmp"); 
        

            try
            {

                 while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();

                    string[] showDetails = line.Split(',');
                    show.Id = UInt64.Parse(showDetails[0]);
                    show.title = showDetails[1];
                    show.season = int.Parse(showDetails[2]);
                    show.episode = int.Parse(showDetails[3]);
                    show.writers = showDetails[4];
                    show.genres = showDetails[5];

                     
                    

                    searchFor(searchItem);

                }

                sr.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            void searchFor(string searchItem)
            {

                string findSubString = searchItem;
                 
                // System.Console.WriteLine("find string show process " + findSubString);

                if (show.genres.Contains(findSubString.ToUpper()) || show.title.Contains(findSubString.ToUpper()))
                {
                    Console.WriteLine("\t" + show.title + " Season: " + show.season 
                        + " Episode: " + show.episode + " " + show.writers + " " + show.genres);
                    hitCount++;
                }

                if (sr.EndOfStream)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(hitCount + " Show(s) contains " + findSubString);
                    Console.ForegroundColor = ConsoleColor.White;
                    VideoProcess videoProcess = new VideoProcess();
                }
            }

        }

    }

}

