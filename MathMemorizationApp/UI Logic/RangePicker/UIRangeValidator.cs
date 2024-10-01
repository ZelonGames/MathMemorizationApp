using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp.RangePicker
{
    /// <summary>
    /// Prevents the user from selecting an invalid range, eg min is higher than max
    /// </summary>
    public class UIRangeValidator(UIRangePicker uIRangePicker, int range)
    {
        public event Action? ValidationCompleted;
        private readonly UIRangePicker uIRangePicker = uIRangePicker;
        private readonly int range = range;

        public void UpdateMaxPickerRange()
        {
            int minPickerValue = uIRangePicker.GetMinValue();
            int maxPickerValue = uIRangePicker.GetMaxValue();
            uIRangePicker.maxPicker.ItemsSource = Enumerable.Range(minPickerValue, range).ToList();
            uIRangePicker.maxPicker.SelectedIndex = uIRangePicker.maxPicker.Items.IndexOf(maxPickerValue.ToString());
            ValidationCompleted?.Invoke();
        }

        public void UpdateMinPickerRange()
        {
            int minPickerValue = uIRangePicker.GetMinValue();
            int maxPickerValue = uIRangePicker.GetMaxValue();
            uIRangePicker.minPicker.ItemsSource = Enumerable.Range(1, maxPickerValue).ToList();
            uIRangePicker.minPicker.SelectedIndex = uIRangePicker.minPicker.Items.IndexOf(minPickerValue.ToString());
            ValidationCompleted?.Invoke();
        }
    }
}
