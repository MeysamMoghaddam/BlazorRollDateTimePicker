using System;
using System.Collections.Generic;
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
        /// 2017-10-21 23:52:50
        /// </summary>
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        [Parameter] public DateTimePickerOption Options { get; set; }
        private DotNetObjectReference<DateTimePicker>? dotNetHelper;
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
        public async void Confirm(string Date) => await ValueChanged.InvokeAsync(Date);     
    }


}