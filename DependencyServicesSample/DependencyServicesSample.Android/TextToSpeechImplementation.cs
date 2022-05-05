using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Speech.Tts;
using DependencyServicesSample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServicesSample.Droid
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener

    {
        TextToSpeech speaker;
        string toSpeak;

        [Obsolete]
        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(Forms.Context, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
        #endregion
    }
}
