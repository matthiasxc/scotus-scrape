using System;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using scotus_scan.Model;
using Windows.Storage.AccessCache;
using scotus_scan.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace scotus_scan.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //public LoadFileViewModel LoadFileViewModel;

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private string _clock = "Starting...";
        private int _counter;
        private RelayCommand _incrementCommand;
        private RelayCommand<string> _navigateCommand;
        private bool _runClock;
        private RelayCommand _sendMessageCommand;
        private RelayCommand _showDialogCommand;
        private string _welcomeTitle = string.Empty;

        public string Clock
        {
            get
            {
                return _clock;
            }
            set
            {
                Set(ref _clock, value);
            }
        }

        #region Properties


        private LoadFileViewModel _loadFileViewModel; 
        public LoadFileViewModel LoadFileViewModel
        {
            get { return _loadFileViewModel; }
            set { Set(ref _loadFileViewModel, value); }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        private ObservableCollection<Case> _scotusCases = new ObservableCollection<Case>();
        public ObservableCollection<Case> ScotusCases
        {
            get { return _scotusCases; }
            set { Set(ref _scotusCases, value); }
        }

        private ObservableCollection<Case> _filteredScotusCases = new ObservableCollection<Case>();
        public ObservableCollection<Case> FilteredScotusCases
        {
            get { return _filteredScotusCases; }
            set { Set(ref _filteredScotusCases, value); }
        }

        private DateTime _beginDate = new DateTime(2005, 1, 1);
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { Set(ref _beginDate, value); }
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { Set(ref _endDate, value); }
        }

        private int _maxMajority = 0;
        public int MaxMajority
        {
            get { return _maxMajority; }
            set { Set(ref _maxMajority, value); }
        }

        private bool _sortAscending = false;
        public bool SortAscending
        {
            get { return _sortAscending; }
            set { Set(ref _sortAscending, value); }
        }


        private Case _selectedCase = null;
        public Case SelectedCase
        {
            get { return _selectedCase; }
            set { Set(ref _selectedCase, value); }
        }

        #region Variable Selection Properties


        private double _maxMajorityCount = 9.0;
        public double MaxMajorityCount
        {
            get { return _maxMajorityCount; }
            set { Set(ref _maxMajorityCount, value); }
        }

        private double _minMajorityCount = 3.0;
        public double MinMajorityCount
        {
            get { return _minMajorityCount; }
            set { Set(ref _minMajorityCount, value); }
        }

        private double _maxMinorityCount = 4.0;
        public double MaxMinorityCount
        {
            get { return _maxMinorityCount; }
            set { Set(ref _maxMinorityCount, value); }
        }

        private double _minMinorityCount = 0.0;
        public double MinMinorityCount
        {
            get { return _minMinorityCount; }
            set { Set(ref _minMinorityCount, value); }
        }

        private List<int> _majJusticeList = new List<int>();
        public List<int> MajJusticeList
        {
            get { return _majJusticeList; }
            set { Set(ref _majJusticeList, value); }
        }

        private List<int> _selectedMajJustices = new List<int>();
        public List<int> SelectedMajJustices
        {
            get { return _selectedMajJustices; }
            set { Set(ref _selectedMajJustices, value); }
        }

        private List<int> _minJusticeList = new List<int>();
        public List<int> MinJusticeList
        {
            get { return _minJusticeList; }
            set { Set(ref _minJusticeList, value); }
        }

        private List<int> _selectedMinJustices = new List<int>();
        public List<int> SelectedMinJustices
        {
            get { return _selectedMinJustices; }
            set { Set(ref _selectedMinJustices, value); }
        }


        private bool _checkMajorityVote = false;
        public bool CheckMajorityVote
        {
            get { return _checkMajorityVote; }
            set { Set(ref _checkMajorityVote, value); }
        }


        private bool _checkMinorityVote = false;
        public bool CheckMinorityVote
        {
            get { return _checkMinorityVote; }
            set { Set(ref _checkMinorityVote, value); }
        }
        #endregion



        #endregion

        #region Methods
        
        private ScotusVoteTotal parseVote(ScotusVoteTotal voteTotal, ScotusRow vote)
        {
            if(vote.majority == 1)
            {
                voteTotal.MinorityVotes.Add(vote.justice);
            }
            else if (vote.majority == 2)
            {
                voteTotal.MajorityVotes.Add(vote.justice);
            }

            return voteTotal;
        }

        #endregion

        #region Commands

        private RelayCommand _parseScotusFileCommand;

        /// <summary>
        /// Gets the LoadAndParseFileCommand.
        /// </summary>
        public RelayCommand ParseScotusFileCommand
        {
            get
            {
                return _parseScotusFileCommand
                    ?? (_parseScotusFileCommand = new RelayCommand( async() =>
                    {
                        if (LoadFileViewModel.FileTokens.Count > 0)
                        {
                            var file = await StorageApplicationPermissions.FutureAccessList.GetFileAsync(LoadFileViewModel.FileTokens.FirstOrDefault());
                            IsLoading = true;
                            var stream = await file.OpenReadAsync();
                            var inputStream = stream.GetInputStreamAt(0);
                            var scotusRows = new List<ScotusRow>();

                            using (CsvFileReader csvReader = new CsvFileReader(await file.OpenStreamForReadAsync()))
                            {
                                CsvRow row = new CsvRow();
                                while (csvReader.ReadRow(row))
                                {
                                    var scotusRow = new ScotusRow();
                                    scotusRow.ParseScotusRow(row);
                                    scotusRows.Add(scotusRow);
                                }
                            }

                            var tempCases = SortOutScotusData(scotusRows);
                            ScotusCases = tempCases;
                            Debug.WriteLine("What the fuck ScotusCases.count = " + ScotusCases.Count());
                            FilteredScotusCases = SortOutScotusData(scotusRows);
                        }
                    }));
            }
        }

        private ObservableCollection<Case> SortOutScotusData(List<ScotusRow> rawData)
        {
            Dictionary<string, Case> allCases = new Dictionary<string, Case>();
            foreach(ScotusRow sr in rawData)
            {
                // if it doesn't have this case yet, populate the case 
                if (!allCases.ContainsKey(sr.caseId))
                {
                    var newCase = new Case()
                    {
                        CaseId = sr.caseId,
                        Court = sr.chief,
                        DecisionDate = sr.dateDecision,
                        ArgumentDate = sr.dateArgument,
                        Term = sr.term,
                        CaseName = sr.caseName,
                        OpinionWriterId = sr.majOpinWriter,
                        PartisanDecision = sr.decisionDirection
                    };
                    var voteDetail = new ScotusVoteTotal()
                    {
                        CaseId = sr.caseId,
                        MajorityCount = sr.majVotes,
                        MinorityCount = sr.minVotes,
                        IsEqualVote = sr.minVotes == sr.majVotes
                    };
                    newCase.VoteDetails = voteDetail;
                    newCase.Dockets.Add(sr.docketId);
                    allCases.Add(sr.caseId, newCase);
                }

                if(allCases[sr.caseId].Dockets[0] == sr.docketId) { 
                    if (sr.majority == 2)
                    {
                        allCases[sr.caseId].VoteDetails.MajorityVotes.Add(sr.justice);
                    } else if(sr.majority == 1)
                    {
                        allCases[sr.caseId].VoteDetails.MinorityVotes.Add(sr.justice);
                    }
                }
                else if (allCases[sr.caseId].Dockets.FirstOrDefault(d => d == sr.docketId) == null)
                {
                    allCases[sr.caseId].Dockets.Add(sr.docketId);
                }
            }
            var casesAsList = new ObservableCollection<Case>();
            int typicalSplit = 0;
            int atypicalSplit = 0;
            foreach (KeyValuePair<string, Case> kvp in allCases)
            {
                kvp.Value.VoteDetails.ParseVotes();
                if(kvp.Value.VoteDetails.MajorityCount <= 9) {
                    if (kvp.Value.Court == "Roberts")
                    {
                        kvp.Value.VoteSplit = Case.EvalSplit(kvp.Value.VoteDetails);
                        if (kvp.Value.VoteSplit == VoteResult.TypicalSplit)
                            typicalSplit++;
                        if (kvp.Value.VoteSplit == VoteResult.NonTypicalSplit)
                            atypicalSplit++;
                        casesAsList.Add(kvp.Value);
                    }

                    //casesAsList.Add(kvp.Value);
                }
                
            }

            Debug.WriteLine("Typical Split Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.TypicalSplit));
            Debug.WriteLine("ATypical Split Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.NonTypicalSplit));
            Debug.WriteLine("Unanimous Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.Unanimous));
            Debug.WriteLine("Mixed Minority Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.MixedMinority));
            Debug.WriteLine("Con Minority Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.ConMinority));
            Debug.WriteLine("Lib Minority Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.LibMinority));
            Debug.WriteLine("Single Dissent Count = " + casesAsList.Count(t => t.VoteSplit == VoteResult.SingleDissent));


            return casesAsList;
        }

        private RelayCommand _filterScotusCases;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand FilterScotusCases
        {
            get
            {
                return _filterScotusCases
                    ?? (_filterScotusCases= new RelayCommand( async() =>
                    {
                        Debug.WriteLine("What the fuck ScotusCases.count = " + ScotusCases.Count());

                        FilteredScotusCases.Clear();
                        ObservableCollection<Case> filteredCases = new ObservableCollection<Case>();
                        foreach(Case c in ScotusCases)
                        {
                            // filter the list by the min & maj numbers
                            if(c.VoteDetails.MajorityCount <= MaxMajorityCount && c.VoteDetails.MajorityCount >= MinMajorityCount &&
                                c.VoteDetails.MinorityCount <= MaxMinorityCount && c.VoteDetails.MinorityCount >= MinMinorityCount)
                            {
                                bool isMajorityCheckComplete = true;
                                bool isMinorityCheckComplete = true;
                                if (CheckMajorityVote)
                                {
                                    foreach(int justice in SelectedMajJustices )
                                    {
                                        if (!c.VoteDetails.MajorityVotes.Contains(justice))
                                        {
                                            isMajorityCheckComplete = false;
                                        }                                        
                                    }                                    
                                }

                                if (CheckMinorityVote)
                                {
                                    foreach (int justice in SelectedMinJustices)
                                    {
                                        if (!c.VoteDetails.MinorityVotes.Contains(justice))
                                        {
                                            isMinorityCheckComplete = false;
                                        }
                                    }
                                }

                                if(isMajorityCheckComplete && isMinorityCheckComplete)
                                {
                                    FilteredScotusCases.Add(c);
                                }
                            }
                        }
                    }));
            }
        }

        #endregion




        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Counter clicked {0} times", ++_counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand<string>(
                           p => _navigationService.NavigateTo(ViewModelLocator.SecondPageKey, p),
                           p => !string.IsNullOrEmpty(p)));
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Testing",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello Universal Application", "it works...");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            Initialize();
        }

        public void RunClock()
        {
            _runClock = true;

            Task.Run(async () =>
            {
                while (_runClock)
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            Clock = DateTime.Now.ToString("HH:mm:ss");
                        });

                        await Task.Delay(1000);
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        public void StopClock()
        {
            _runClock = false;
        }

        private async Task Initialize()
        {
            try
            {
                this.LoadFileViewModel = new LoadFileViewModel();
                this.LoadFileViewModel.LoadFilesOnStartCommand.Execute(null);
                var item = await _dataService.GetData();
                WelcomeTitle = item.Title;

                MajJusticeList = new List<int>() { 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116 };
                MinJusticeList = new List<int>() { 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116 };
            }
            catch (Exception ex)
            {
                // Report error here
                WelcomeTitle = ex.Message;
            }
        }
    }
}