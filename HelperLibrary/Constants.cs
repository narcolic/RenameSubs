using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HelperLibrary
{
    public static class Constants
    {
        #region FileExtensions...
        public static readonly List<string> SubtitleFileExtensions = new List<string>() { ".srt", ".sub" };

        public static readonly List<string> VideoFileExtensions = new List<string>() { ".mkv", ".avi", ".mp4", ".mpg", ".mpeg" };
        #endregion

        #region TvSeries Regex...
        public static readonly List<Regex> TvSeries_Regex_SeasonEpisode = new List<Regex>()
        {
            new Regex(@"S(?<season>\d{1,2})E(?<episode>\d{1,2})", RegexOptions.IgnoreCase),
            new Regex(@"(?<season>\d{1,2})x(?<episode>\d{1,2})", RegexOptions.IgnoreCase)
        };
        #endregion

    }
}
