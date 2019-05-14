using System;
using System.Collections.Generic;

namespace Xamarin.Usabilla
{
    public enum XUFormLoadResult
    {
        FormDidSucceedLoading,
        FormDidFailLoading
    }
}

namespace Xamarin.Usabilla.PCL
{
    public interface IUsabillaXamarin
    {
        bool DebugEnabled { get; set; }

        IDictionary<string, string> CustomVariables { get; set; }

        IList<string> DefaultMasks { get; }

        void Initialize(string appId);

        void SendEvent(string anEvent);

        void Reset();

        void ShowFeedbackForm(string formId, Action<XUFormLoadResult> result);

        void ShowFeedbackFormWithScreenshot(string formId, Action<XUFormLoadResult> result);

        bool Dismiss();

        void SetDataMasking(IList<string> masks, char maskCharacter);
    }
}
