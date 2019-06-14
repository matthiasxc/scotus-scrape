using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using scotus_scan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.UI.Xaml;

namespace scotus_scan.ViewModel
{
    public class LoadFileViewModel : ViewModelBase
    {
        private RelayCommand _loadFileCommand;
        private RelayCommand _loadFilesOnStartCommand;

        private const string savedFilesLocation = "savedFiles.json";

        #region Properties 

        private List<string> _fileTokens = new List<string>();
        public List<string> FileTokens
        {
            get { return _fileTokens; }
            set { Set(ref _fileTokens, value); }
        }

        private bool _isLoadingData = false;
        public bool IsLoadingData
        {
            get { return _isLoadingData; }
            set { Set(ref _isLoadingData, value); }
        }

        #endregion

        #region Methods
        private async Task<List<string>> getFileTokensWithPicker(List<string> fileTypes, bool pickMultiple = false)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            foreach (string s in fileTypes)
            {
                picker.FileTypeFilter.Add(s);
            }
            List<string> fileTokens = new List<string>();

            if (pickMultiple)
            {
                var files = await picker.PickMultipleFilesAsync();

                foreach (StorageFile file in files)
                {
                    fileTokens.Add(StorageApplicationPermissions.FutureAccessList.Add(file));
                }
            }
            else
            {
                var file = await picker.PickSingleFileAsync();
                fileTokens.Add(StorageApplicationPermissions.FutureAccessList.Add(file));
            }

            return fileTokens;
        }

        private async Task saveFileTokens(List<string> tokens)
        {            
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(savedFilesLocation, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(tokens));
        }

        #endregion

        public RelayCommand LoadFileWithPickerCommand
        {
            get
            {
                return _loadFileCommand ?? (_loadFileCommand = new RelayCommand(async () =>
                {
                    var fileTypes = new List<string>();
                    fileTypes.Add(".csv");

                    FileTokens = await getFileTokensWithPicker(fileTypes, false);

                    await saveFileTokens(FileTokens);

                }));
            }
        }

        public RelayCommand LoadFilesOnStartCommand
        {
            get
            {
                return _loadFilesOnStartCommand ?? (_loadFilesOnStartCommand = new RelayCommand(async () =>
                {
                    IsLoadingData = true;
                    IEnumerable<string> listOfFiles = _fileTokens as IEnumerable<string>;

                    StorageFolder localFolder = ApplicationData.Current.LocalFolder;

                    // Load the data files
                    var fileItem = await localFolder.TryGetItemAsync(savedFilesLocation);

                    if (fileItem != null)
                    {
                        var file = await localFolder.GetFileAsync(savedFilesLocation);

                        string fileString = await Windows.Storage.FileIO.ReadTextAsync(file);

                        var tokens = JsonConvert.DeserializeObject<IEnumerable<string>>(fileString);
                        FileTokens.Clear();

                        foreach (string token in tokens)
                        {
                            FileTokens.Add(token);
                        }
                    }

                    IsLoadingData = false;

                }));
            }
        }
    }
}
