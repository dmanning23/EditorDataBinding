using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LabelDataBinding
{
    public partial class TestPage : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// Event that the data-binding listens for
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>S
        /// The peice of text that is goin to be changed
        /// </summary>
        private string _testText = "test text";

        /// <summary>
        /// Properties to change the text and raise events when it does
        /// </summary>
        public string TestText
        {
            get
            {
                return _testText;
            }
            set
            {
                if (0 != String.Compare(_testText, value, StringComparison.Ordinal))
                {
                    _testText = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public TestPage()
        {
            //Self-binding page
            BindingContext = this;

            InitializeComponent();
        }

        /// <summary>
        /// Called when the button gets pressed.  Changes the text of the label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeText(object sender, EventArgs e)
        {
            TestText = "It worked!";
        }

        /// <summary>
        /// Called when a data bound property changes
        /// </summary>
        /// <param name="propertyName"></param>
        void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
