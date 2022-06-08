
export function loadRollPicker(identifier, option, value, dotNetHelper) {
    new Rolldate({
        el: '#' + identifier,
        format: option.format,
        beginYear: option.beginYear,
        endYear: option.endYear,
        lang: option.language,
        value: value,
        confirm: function (date) {
            dotNetHelper.invokeMethodAsync('Confirm', date);
        }
    })

} 