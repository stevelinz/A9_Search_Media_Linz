using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MediaProject
{
    public class MovieProcess : Media
    {
        public List<Movie> Movies { get; set; }

        string _searchItem;
        public MovieProcess(string searchItem)
        {
           this._searchItem = searchItem;

        }

        public MovieProcess()
        {
            int hitCount = 0;
            int singleRun = 0;
            
            Movies = new List<Movie>();
            Movie movie = new Movie();

            StreamReader sr = new StreamReader("movies.csv");

            try
            {      
                    System.Console.Write("\nSearch by Title or Genres ");
                    _searchItem = Console.ReadLine();
                    System.Console.WriteLine();
                
                File.WriteAllText("search.tmp", _searchItem);  

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();

                    string[] movieDetails = line.Split(',');
                    movie.Id = UInt64.Parse(movieDetails[0]);
                    movie.title = movieDetails[1];
                    movie.genres = movieDetails[2];


                    if (singleRun > 0)
                    {
                        singleRun++;
                        continue;
                    }         
                        searchFor(_searchItem);
                }

                sr.Close();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            void searchFor(string _searchItem)
            {

                string findSubString = _searchItem;


                if (movie.genres.Contains(findSubString.ToUpper()) || movie.title.Contains(findSubString.ToUpper()))
                {
                    Console.WriteLine("\t" + movie.title + movie.genres);
                    hitCount++;
                }

                if (sr.EndOfStream)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(hitCount + " Movie(s) contains " + findSubString);
                    Console.ForegroundColor = ConsoleColor.White;
                    ShowProcess showProcess = new ShowProcess();

                }
               
            }        
           
        } 

    }

}






