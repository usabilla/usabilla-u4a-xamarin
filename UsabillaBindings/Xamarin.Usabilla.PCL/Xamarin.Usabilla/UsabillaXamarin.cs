using System;
using System.Collections.Generic;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }


        public IDictionary<string, string> CustomVariables
        {
            get
            {
                throw new NotImplementedException("Dummy Implementation for IDictionary, get and should not be called");
            }

            set
            {
                throw new NotImplementedException("Dummy Implementation for IDictionary, set and should not be called");
            }
        }

        public void Initialize(string appId)
        {
            throw new NotImplementedException("Dummy Implementation for Initialize and should not be called");
        }
        public void SendEvent(string anEvent)
        {
            throw new NotImplementedException("Dummy Implementation for SendEvent and should not be called");
        }
        public void Reset()
        {
            throw new NotImplementedException("Dummy Implementation for Reset and should not be called");
        }
        public void ShowFeedbackForm(string formId, Action<XUFormLoadResult> result)
        {
            throw new NotImplementedException("Dummy Implementation for ShowFeedbackForm and should not be called");
        }
        public bool Dismiss()
        {
            throw new NotImplementedException("Dummy Implementation for Dismiss and should not be called");
        }
    }
}
