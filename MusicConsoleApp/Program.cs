using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../Songs.json");
            string music = reader.ReadToEnd();
            reader = new StreamReader("../../../BadWords.json");
            string badWords = reader.ReadToEnd();
            List<Music> Playlist = JsonConvert.DeserializeObject<List<Music>>(music);
            List<BadWord> BadWords = JsonConvert.DeserializeObject<List<BadWord>>(badWords);

            BadWords.ForEach(w => Playlist.FindAll(x => x.Lyrics.ToLower().Contains(w.Word)).ForEach(y => y.Lyrics = Regex.Replace(y.Lyrics, w.Word, Regex.Replace(w.Word, "[^0-9.]", "*"), RegexOptions.IgnoreCase)));
            Playlist.FindAll(x => x.Lyrics.ToLower().Contains("*")).ForEach(y => Console.WriteLine(y.Song + " - " + y.Artists + "\n" + y.Lyrics));
        }

        public class Music
        {
            public string Artists { get; set; }
            public string Song { get; set; }
            public string Album { get; set; }
            public string Lyrics { get; set; }

        }
        public class BadWord
        {
            public string Word { get; set; }
        }
    }
}