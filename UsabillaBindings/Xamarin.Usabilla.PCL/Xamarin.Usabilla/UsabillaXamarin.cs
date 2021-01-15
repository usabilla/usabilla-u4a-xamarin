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

        public bool DebugEnabled 
        {
            get
            {
                throw new NotImplementedException("Dummy Implementation for DebugEnabled - get; should not be called");
            }

            set
            {
                throw new NotImplementedException("Dummy Implementation for DebugEnabled - set; should not be called");
            }
        }

        public IDictionary<string, string> CustomVariables
        {
            get
            {
                throw new NotImplementedException("Dummy Implementation for IDictionary - get; should not be called");
            }

            set
            {
                throw new NotImplementedException("Dummy Implementation for IDictionary - set; should not be called");
            }
        }

        public IList<string> DefaultMasks 
        {
            get 
            {
                throw new NotImplementedException("Dummy Implementation for DefaultMasks; should not be called");
            }
        }

        public void Initialize(string appId)
        {
            throw new NotImplementedException("Dummy Implementation for Initialize; should not be called");
        }
        public void SendEvent(string anEvent, Action<IXUFormCompletionResult> result)
        {
            throw new NotImplementedException("Dummy Implementation for SendEvent; should not be called");
        }
        public void Reset()
        {
            throw new NotImplementedException("Dummy Implementation for Reset; should not be called");
        }
        public void ShowFeedbackForm(string formId, Action<IXUFormCompletionResult> result)
        {
            throw new NotImplementedException("Dummy Implementation for ShowFeedbackForm; should not be called");
        }
        public void ShowFeedbackFormWithScreenshot(string formId, Action<IXUFormCompletionResult> result)
        {
            throw new NotImplementedException("Dummy Implementation for ShowFeedbackFormWithScreenshoot; should not be called");
        }
        public bool Dismiss()
        {
            throw new NotImplementedException("Dummy Implementation for Dismiss; should not be called");
        }
        public void SetDataMasking(IList<string> masks = null, char maskCharacter = 'X')
        {
            throw new NotImplementedException("Dummy Implementation for SetDataMasking; should not be called");
        }
        public void PreloadFeedbackForms(IList<string> formIds)
        {
            throw new NotImplementedException("Dummy Implementation for PreloadFeedbackForms; should not be called");
        }

        public void RemoveCachedForms()
        {
            throw new NotImplementedException("Dummy Implementation for RemoveCachedForms; should not be called");
        }
    }
}
