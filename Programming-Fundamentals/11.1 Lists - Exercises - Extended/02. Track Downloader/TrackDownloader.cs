namespace _02.Track_Downloader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrackDownloader
    {
        public static void Main()
        {
            var blackList = Console.ReadLine().Split().ToList();
            var downloadedTracks = new List<string>();
            var currentTrack = Console.ReadLine();
            var contains = false;
            for (int i = 0; ; i++)
            {
                contains = false;
                if (currentTrack == "end")
                {
                    downloadedTracks.Sort();
                    var iterations = downloadedTracks.Count;
                    for (int index = 0; index < iterations; index++)
                    {
                        Console.WriteLine(downloadedTracks[index]);
                    }
                    return;
                    //PrintSortedTracks(downloadedTracks); return;
                    //downloadedTracks.Sort();
                    //Console.WriteLine(string.Join(Environment.NewLine, downloadedTracks)); return;
                }

                for (int index = 0; index < blackList.Count; index++)
                {
                    if (currentTrack.Contains(blackList[index]))
                    {
                        contains = true; break; 
                    }
                }

                if (contains == false)
                {
                    downloadedTracks.Add(currentTrack);
                }
                currentTrack = Console.ReadLine();
            }
        }

        //private static void PrintSortedTracks(List<string> downloadedTracks)
        //{
        //    downloadedTracks.Sort();
        //    var iterations = downloadedTracks.Count;
        //    for (int index = 0; index < iterations; index++)
        //    {
        //        Console.WriteLine(downloadedTracks[index]);
        //    }
        //}
    }
}
