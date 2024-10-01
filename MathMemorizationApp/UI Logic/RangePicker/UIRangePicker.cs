using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp.RangePicker
{
    public class UIRangePicker
    {
        public readonly UIRangePickerEventHandler handler;
        private readonly UIRangeValidator validator;
        public readonly Picker minPicker;
        public readonly Picker maxPicker;
        public readonly int range;

        public UIRangePicker(Picker minPicker, Picker maxPicker, int range)
        {
            this.minPicker = minPicker;
            this.maxPicker = maxPicker;
            this.range = range;

            this.maxPicker.ItemsSource = Enumerable.Range(1, range).ToArray();
            this.maxPicker.SelectedIndex = 9;

            this.minPicker.ItemsSource = Enumerable.Range(1, maxPicker.SelectedIndex + 1).ToArray();
            this.minPicker.SelectedIndex = 0;

            validator = new UIRangeValidator(this);
            handler = new UIRangePickerEventHandler(this, validator);
        }

        public int GetMinValue()
        {
            return minPicker.SelectedItem == null ? 0 : (int)minPicker.SelectedItem;
        }

        public int GetMaxValue()
        {
            return maxPicker.SelectedItem == null ? 0 : (int)maxPicker.SelectedItem;
        }
    }
}
