using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NoLambdas
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
            string bleep = "";

            //Iterate through each bad word in the list of bad words
            foreach (BadWord badWord in BadWords)
            {
                //Iterate through each song in the playlist
                foreach (Music song in Playlist)
                {
                    //check if lyrics of specific song has specific bad word
                    if (song.Lyrics.Contains(badWord.Word))
                    {
                        //Create a copy of the bad word with a bleeped out word the same length
                        bleep = Regex.Replace(badWord.Word, "[^0-9.]", "*");
                        //Within a song's Lyrics replace a Bad Word With the bleeped out word
                        song.Lyrics = Regex.Replace(song.Lyrics, badWord.Word, bleep, RegexOptions.IgnoreCase);
                    }
                }
            }
            //Iterate through song in playlist
            foreach (Music song in Playlist)
            {

                if (song.Lyrics.Contains("*"))
                {
                    //Print song title with artist title and lyrics below
                    Console.WriteLine(song.Song + " - " + song.Artists + "\n" + song.Lyrics);
                }
            }

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