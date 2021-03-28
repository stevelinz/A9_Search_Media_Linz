using System;
using System.Collections.Generic;
using System.IO;

namespace MediaProject
{
    public class VideoProcess : Media
    {
        public List<Video> Videos { get; set; }
        public VideoProcess()
        {
        
            int hitCount = 0;
            Videos = new List<Video>();
            Video video = new Video();
            StreamReader sr = new StreamReader("videos.csv");

            string searchItem = File.ReadAllText("search.tmp"); 

            try
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] videoDetails = line.Split(',');
                    video.Id = UInt64.Parse(videoDetails[0]);
                    video.title = videoDetails[1];
                    video.format = videoDetails[2];
                    video.length = videoDetails[3];
                    video.regions = videoDetails[4];
                    video.genres = videoDetails[5];


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

              


                if (video.genres.Contains(findSubString.ToUpper()) || video.title.Contains(findSubString.ToUpper()))
                {
                    Console.WriteLine("\t" + video.title + " " + video.format + " "
                        + "Length: " + video.length + " Regions: " + video.regions + " " + video.genres);
                    hitCount++;
                }

                if (sr.EndOfStream)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(hitCount + " Video(s) contains " + findSubString);
                    System.Console.WriteLine();
                }
            }
        }
    }
}


