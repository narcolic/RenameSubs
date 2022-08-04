namespace HelperLibrary
{
    public static class FileAnalyzerFactory
    {
        public static FileNameAnalyserBase GetFileAnalyzer(FileTypeCategories fileType)
        {
            switch (fileType)
            {
                case FileTypeCategories.Subtitle:
                    return new SubtitleFileNameAnalyzer();
                default:
                    return new TvSeriesFileNameAnalyzer();
            }
        }
    }
}
