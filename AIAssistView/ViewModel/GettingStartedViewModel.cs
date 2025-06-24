using Syncfusion.Maui.AIAssistView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

#nullable disable
namespace AIAssistView
{
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        #region fields
        private ObservableCollection<IAssistItem> assistItems;
        private AzureAIService azureAIService;
        private bool cancelResponse;
        #endregion

        #region Command
        public ICommand AssistViewRequestCommand { get; set; }
        public ICommand StopRespondingCommand { get; set; }
        #endregion

        #region Constructor
        public GettingStartedViewModel()
        {
            azureAIService = new AzureAIService();
            this.assistItems = new ObservableCollection<IAssistItem>();
            this.AssistViewRequestCommand = new Command<object>(ExecuteRequestCommand);
            this.StopRespondingCommand = new Command(ExecuteStopResponding);
        }
        #endregion

        #region Properties
        public ObservableCollection<IAssistItem> AssistItems
        {
            get
            {
                return this.assistItems;
            }

            set
            {
                this.assistItems = value;
            }
        }

        public bool CancelResponse
        {
            get
            {
                return cancelResponse;
            }
            set
            {
                cancelResponse = value;
                RaisePropertyChanged(nameof(CancelResponse));
            }
        }

        #endregion

        #region Methods
        private async void ExecuteRequestCommand(object obj)
        {
            var request = (obj as Syncfusion.Maui.AIAssistView.RequestEventArgs).RequestItem;
            await this.GetResult(request).ConfigureAwait(true);
        }

        private void ExecuteStopResponding()
        {
            this.CancelResponse = true;
            AssistItem responseItem = new AssistItem() { Text = "You canceled the response" };
            responseItem.ShowAssistItemFooter = false;
            this.AssistItems.Add(responseItem);
        }
        private async Task GetResult(object inputQuery)
        {
            await Task.Delay(1000).ConfigureAwait(true);
            AssistItem request = (AssistItem)inputQuery;
            if (request != null)
            {
                var userAIPrompt = this.GetUserAIPrompt(request.Text);
                var response = await azureAIService!.GetResultsFromAI(request.Text, userAIPrompt).ConfigureAwait(true);
                response = response.Replace("\n", "<br>");
                await Task.Delay(1000).ConfigureAwait(true);
                if (!CancelResponse)
                {
                    AssistItem responseItem = new AssistItem() { Text = response };
                    responseItem.RequestItem = inputQuery;
                    this.AssistItems.Add(responseItem);
                }
            }

            this.CancelResponse = false;
        }
        private string GetUserAIPrompt(string userPrompt)
        {
            string userQuery = $"Given User query: {userPrompt}." +
                      $"\nSome conditions need to follow:" +
                      $"\nGive heading of the topic and simplified answer in 4 points with numbered format" +
                      $"\nGive as string alone" +
                      $"\nRemove ** and remove quotes if it is there in the string.";
            return userQuery;
        }
        #endregion

        #region PopertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
