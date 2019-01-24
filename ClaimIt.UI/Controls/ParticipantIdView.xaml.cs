using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Threading.Tasks;
using System.Linq;

namespace ClaimIt.UI.Controls
{
    public partial class ParticipantIdView : ContentView
    {
        #region Bindable properties

        public static readonly BindableProperty ParticipantIdProperty =
           BindableProperty.Create(propertyName: nameof(ParticipantId),
                                   returnType: typeof(string),
                                   declaringType: typeof(ParticipantIdView),
                                   defaultValue: String.Empty, propertyChanged: OnParticipantIdChanged);


        static void OnParticipantIdChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Property changed implementation goes here
            ParticipantIdView participantIdView = bindable as ParticipantIdView;
            participantIdView.ParId.Update(newValue.ToString());
        }

        public string ParticipantId
        {
            get { return (string)GetValue(ParticipantIdProperty); }
            set
            {
                SetValue(ParticipantIdProperty, value);

            }
        }

        #endregion

        #region Properties

        public ParticipantId ParId { get; set; }

        #endregion

        public ParticipantIdView()
        {
            InitializeComponent();
            ParId = new ParticipantId();
            this.grRoot.BindingContext = this;
        }



        #region Commands

        public IMvxCommand<string> EnterCommand => new MvxCommand<string>(Enter);

        protected void Enter(string input)
        {

            if (this.ParticipantId.Length <= 10 && this.ParticipantId.Length >= 0)
            {
                if (input.Equals("BackSpace"))
                {
                    if (this.ParticipantId.Length == 0) return;

                    this.ParticipantId = this.ParticipantId.Remove(this.ParticipantId.Length - 1);
                }
                else
                {
                    if (this.ParticipantId.Length == 10) return;
                    this.ParticipantId += input;
                }

            }

        }


    }

    #endregion
}

public class ParticipantId : MvxViewModel
{
    public void Update(string input)
    {
        var chars = input.ToCharArray().Select((c, index) => new { Text = c, Index = index }).ToArray();

        this.Letter1 = chars.FirstOrDefault(c => c.Index == 0)?.Text.ToString();
        this.Letter2 = chars.FirstOrDefault(c => c.Index == 1)?.Text.ToString();
        this.Letter3 = chars.FirstOrDefault(c => c.Index == 2)?.Text.ToString();
        this.Letter4 = chars.FirstOrDefault(c => c.Index == 3)?.Text.ToString();
        this.Letter5 = chars.FirstOrDefault(c => c.Index == 4)?.Text.ToString();
        this.Letter6 = chars.FirstOrDefault(c => c.Index == 5)?.Text.ToString();
        this.Letter7 = chars.FirstOrDefault(c => c.Index == 6)?.Text.ToString();
        this.Letter8 = chars.FirstOrDefault(c => c.Index == 7)?.Text.ToString();
        this.Letter9 = chars.FirstOrDefault(c => c.Index == 8)?.Text.ToString();
        this.Letter10 = chars.FirstOrDefault(c => c.Index == 9)?.Text.ToString();

    }

    #region Letter1

    private string _letter1;
    public string Letter1
    {
        get
        {
            return _letter1;
        }
        set
        {
            SetProperty(ref _letter1, value);
        }
    }
    #endregion

    #region Letter2

    private string _letter2;
    public string Letter2
    {
        get
        {
            return _letter2;
        }
        set
        {
            SetProperty(ref _letter2, value);
        }
    }
    #endregion

    #region Letter3

    private string _letter3;
    public string Letter3
    {
        get
        {
            return _letter3;
        }
        set
        {
            SetProperty(ref _letter3, value);
        }
    }
    #endregion

    #region Letter4

    private string _letter4;
    public string Letter4
    {
        get
        {
            return _letter4;
        }
        set
        {
            SetProperty(ref _letter4, value);
        }
    }
    #endregion

    #region Letter5

    private string _letter5;
    public string Letter5
    {
        get
        {
            return _letter5;
        }
        set
        {
            SetProperty(ref _letter5, value);
        }
    }
    #endregion

    #region Letter6

    private string _letter6;
    public string Letter6
    {
        get
        {
            return _letter6;
        }
        set
        {
            SetProperty(ref _letter6, value);
        }
    }
    #endregion

    #region Letter7

    private string _letter7;
    public string Letter7
    {
        get
        {
            return _letter7;
        }
        set
        {
            SetProperty(ref _letter7, value);
        }
    }
    #endregion

    #region Letter8

    private string _letter8;
    public string Letter8
    {
        get
        {
            return _letter8;
        }
        set
        {
            SetProperty(ref _letter8, value);
        }
    }
    #endregion

    #region Letter9

    private string _letter9;
    public string Letter9
    {
        get
        {
            return _letter9;
        }
        set
        {
            SetProperty(ref _letter9, value);
        }
    }
    #endregion

    #region Letter10

    private string _letter10;
    public string Letter10
    {
        get
        {
            return _letter10;
        }
        set
        {
            SetProperty(ref _letter10, value);
        }
    }
    #endregion


}
