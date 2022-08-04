using HelperLibrary;
using HelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RenameSubs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Open_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker { SuggestedStartLocation = PickerLocationId.Desktop };
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            if (!Equals(folder, null))
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                List<StorageFile> files = new List<StorageFile>();
                files.AddRange(await folder.GetFilesAsync());
                FolderContentReader folderContentReader = new FolderContentReader(files);

                var tvSeriesFiles = folderContentReader.TvSeriesFiles;
                var tvSeriesSubFiles = folderContentReader.TvSeriesSubtitleFiles;
                var movieFiles = folderContentReader.MovieFiles;
                var movieSubFiles = folderContentReader.MovieSubtitleFiles;

                FileNameAnalyserBase tvSeriesFileNameAnalyzer = FileAnalyzerFactory.GetFileAnalyzer(FileTypeCategories.TvSeries);

                //List<TvSeriesTitle> tvSeriesVideoModels = tvSeriesFileNameAnalyzer.ConvertPathsToModels(tvSeriesFiles).OfType<TvSeriesTitle>().ToList();
                //List<TvSeriesTitle> tvSeriesSubtitlesModels = tvSeriesFileNameAnalyzer.ConvertPathsToModels(tvSeriesSubFiles).OfType<TvSeriesTitle>().ToList();
            }
        }
    }
}
