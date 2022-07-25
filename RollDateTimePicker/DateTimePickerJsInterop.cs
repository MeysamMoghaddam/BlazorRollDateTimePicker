using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollDateTimePicker
{
    public interface IDateTimePickerJsInterop
    {
        Task Load(string Identifier, DateTimePickerOption Option, string Value, DotNetObjectReference<DateTimePicker>? dotNetHelper);
    }
    public class DateTimePickerJsInterop : IAsyncDisposable, IDateTimePickerJsInterop
    {
        private readonly Lazy<Task<IJSObjectReference>> rolldate;
        private readonly Lazy<Task<IJSObjectReference>> main;

        public DateTimePickerJsInterop(IJSRuntime jSRuntime)
        {
            rolldate = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/RollDateTimePicker/rolldate.min.js").AsTask());

            main = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/RollDateTimePicker/main.js").AsTask());
            Init();
        }
        public async Task Init()
        {
            await rolldate.Value;
            await main.Value;
        }
        public async Task Load(string Identifier, DateTimePickerOption Option, string Value, DotNetObjectReference<DateTimePicker>? dotNetHelper)
        {
            await rolldate.Value;
            var module = await main.Value;
            await module.InvokeVoidAsync("loadRollPicker", Identifier, Option, Value, dotNetHelper);
        }
        public async ValueTask DisposeAsync()
        {
            if (main != null)
            {
                main.Value.Dispose();
            }
        }
    }
}
