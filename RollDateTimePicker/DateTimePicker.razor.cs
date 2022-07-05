using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace RollDateTimePicker
{
    public partial class DateTimePicker
    {
        [Parameter] public string Identifier { get; set; }
        [Parameter] public string PlaceHolder { get; set; }
        /// <summary>
        /// Gets the culture name in the format languagecode2-country/regioncode2.
        /// example: en-US
        /// </summary>
        [Parameter] public string CultureInfoName { get; set; } = "en-US";
        /// <summary>
        /// 2017-10-21 23:52:50
        /// </summary>
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        [Parameter] public DateTime MValue { get; set; }
        [Parameter] public EventCallback<DateTime> MValueChanged { get; set; }

        [Parameter] public DateTimePickerOption Options { get; set; }
        private DotNetObjectReference<DateTimePicker>? dotNetHelper;

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dotNetHelper = DotNetObjectReference.Create(this);
                if (!string.IsNullOrEmpty(Identifier) && !string.IsNullOrWhiteSpace(Identifier))
                    await dateTimePicker.Load(Identifier, Options, Value, dotNetHelper);
            }
        }
        [JSInvokable]
        public async void Confirm(string Date)
        {
            await ValueChanged.InvokeAsync(Date);
            var pcul = new CultureInfo(CultureInfoName);
            if(DateTime.TryParseExact(Date, Options.DateFormat, pcul,DateTimeStyles.None,out var mValue))            
                await MValueChanged.InvokeAsync(mValue);            
            
        }
    }
}