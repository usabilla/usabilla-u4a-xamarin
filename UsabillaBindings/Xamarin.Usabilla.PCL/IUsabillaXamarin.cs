using System;
using System.Collections.Generic;

public enum XUFormLoadResult
{
    FormDidSucceedLoading,
    FormDidFailLoading
}

namespace Xamarin.Usabilla.PCL
{
    public interface IUsabillaXamarin
    {
        IDictionary<string, string> CustomVariables { get; set; }

        void Initialize(String appId);

        void SendEvent(string anEvent);

        void Reset();

        void ShowFeedbackForm(string formId, Action<XUFormLoadResult> result);
    }
}
