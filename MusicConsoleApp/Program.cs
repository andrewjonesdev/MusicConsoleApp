using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("../../../songs.json");
            string json = r.ReadToEnd();
            List<Music> Playlist = JsonConvert.DeserializeObject < List <Music>>(json);
            Playlist.ForEach(x => Console.WriteLine(x.Song));
            Playlist.FindAll(x => x.Artists.Contains("Drake")).ForEach(y=> Console.WriteLine(y.Song + " - " + y.Artists));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("lean")).ForEach(y => Console.WriteLine(y.Song + " - " + y.Artists));
        }

        public class Music
        {
            public string Artists { get; set; }
            public string Song { get; set; }
            public string Album { get; set; }
            public string Lyrics { get; set; }

        }
    }
}
