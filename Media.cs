using System;

namespace MediaProject
{
    public abstract class Media  
    {
        public UInt64 Id { get; set; }
        public string title { get; set; }
        public string genres { get; set; }
      
       

        public virtual string Display()
        {
            return $"Id: {Id}\n Title: {title}\n Genres: {genres}\n";
        }
    }

    public class Movie : Media
    {
                public override string Display()
        {
            return $"Id: {Id}\nTitle: {title}\nGenres: {genres}\n";
            
        }
    }

        public class Video : Media
    {
        public string format { get; set; }
        public string length { get; set; }
        public string regions { get; set; }

        public override string Display()
        {
            return $"Id: {Id}\n Title: {title}\n Format: {format}\n Length: {length}\n Regions: {regions}\n Genres: {genres}\n";
        }
    }

    public class Show : Media
    {
        public int season { get; set; }
        public int episode { get; set; }
        public string writers { get; set; }

        public override string Display()
        {
            return $"Id: {Id}\nTitle: {title}\nSeason: {season}\nEpisode: {episode}\nWriters: {writers}\nGenres: {genres}\n";
        }
    }
}
