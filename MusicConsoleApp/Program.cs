using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains(" lean ")).ForEach(y => Console.WriteLine(y.Song + " - " + y.Artists));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("fuck")).ForEach(y => y.Lyrics=Regex.Replace(y.Lyrics,"fuck", "****", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("nigg")).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, "nigg", "****", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("bitch")).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, "bitch", "*****", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("pussy")).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, "pussy", "*****", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains(" ass ")).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, " ass ", "***", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("shit")).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, "shit", "****", RegexOptions.IgnoreCase));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("*")).ForEach(y => Console.WriteLine(y.Song + " - " + y.Artists + "\n" + y.Lyrics));
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
