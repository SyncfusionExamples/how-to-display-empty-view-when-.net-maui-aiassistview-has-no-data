using Syncfusion.Maui.AIAssistView;
namespace AIAssistView
{
	    public partial class MainPage : ContentPage
	    {
	        public MainPage()
	        {
	            InitializeComponent();
	        }
	    }
        public class CustomAIAssiststView : SfAIAssistView
        {
            public static readonly BindableProperty AssistChatViewProperty = BindableProperty.Create(nameof(AssistChatView), typeof(CustomAssistViewChat), typeof(CustomAIAssiststView));

            public CustomAssistViewChat AssistChatView
            {
                get { return (CustomAssistViewChat)this.GetValue(AssistChatViewProperty); }
                set { this.SetValue(AssistChatViewProperty, value); }
            }
            public CustomAIAssiststView() { }

            protected override AssistViewChat CreateAssistChat()
            {
                // Returning custom implementation of AssistViewChat
                AssistChatView = new CustomAssistViewChat(this);
                return AssistChatView;
            }
        }
        public class CustomAssistViewChat : AssistViewChat
        {
            public CustomAssistViewChat(SfAIAssistView assistView) : base(assistView)
            {
                //Customize the AssistViewChat
            }
         }
}
