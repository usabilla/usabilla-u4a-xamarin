using System;
using System.Collections.Generic;

namespace Xamarin.Usabilla
{
    public interface IXUFormCompletionResult
    {
        bool isFormSucceeded { get; }
        string? formId { get; }
        IUBFeedback? result { get; }
        bool? isRedirectToAppStoreEnabled { get; }
        IUBError? error { get; }
    }
    public interface IUBError
    {
        string description { get; }
    }
    public interface IUBFeedback
    {
        int Rating { get; }
        int AbandonedPageIndex { get; }
        bool Sent { get; }
    }
}

namespace Xamarin.Usabilla.PCL
{
    public interface IUsabillaXamarin
    {
        bool DebugEnabled { get; set; }

        IDictionary<string, string> CustomVariables { get; set; }

        IList<string> DefaultMasks { get; }

        void Initialize(string appId, Action<IXUFormCompletionResult> result);

        void SendEvent(string anEvent, Action<IXUFormCompletionResult> result);

        void Reset();

        void ShowFeedbackForm(string formId, Action<IXUFormCompletionResult> result);

        void ShowFeedbackFormWithScreenshot(string formId, Action<IXUFormCompletionResult> result);

        bool Dismiss();

        void SetDataMasking(IList<string> masks, char maskCharacter);

        void PreloadFeedbackForms(IList<string> formIds);

        void RemoveCachedForms();

        string LocalizedStringFile  { get; set; }

}
}