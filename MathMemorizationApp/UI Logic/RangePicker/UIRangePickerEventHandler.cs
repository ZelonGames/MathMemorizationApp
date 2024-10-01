using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp.RangePicker
{
    public class UIRangePickerEventHandler
    {
        public event Action? ValidationCompleted;
        private readonly UIRangePicker uIRangePicker;
        private readonly UIRangeValidator uIRangeValidator;

        public UIRangePickerEventHandler(UIRangePicker uIRangePicker, UIRangeValidator uIRangeValidator)
        {
            this.uIRangePicker = uIRangePicker;
            this.uIRangeValidator = uIRangeValidator;

            uIRangePicker.minPicker.SelectedIndexChanged += MinPicker_SelectedIndexChanged;
            uIRangePicker.maxPicker.SelectedIndexChanged += MaxPicker_SelectedIndexChanged;
        }

        private void MinPicker_SelectedIndexChanged(object? sender, EventArgs e)
        {
            uIRangePicker.maxPicker.SelectedIndexChanged -= MaxPicker_SelectedIndexChanged;
            uIRangeValidator.UpdateMaxPickerRange();
            uIRangePicker.maxPicker.SelectedIndexChanged += MaxPicker_SelectedIndexChanged;
            ValidationCompleted?.Invoke();
        }

        private void MaxPicker_SelectedIndexChanged(object? sender, EventArgs e)
        {
            uIRangePicker.minPicker.SelectedIndexChanged -= MinPicker_SelectedIndexChanged;
            uIRangeValidator.UpdateMinPickerRange();
            uIRangePicker.minPicker.SelectedIndexChanged += MinPicker_SelectedIndexChanged;
            ValidationCompleted?.Invoke();
        }
    }
}
