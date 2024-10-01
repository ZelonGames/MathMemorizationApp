using MathMemorizationApp.RangePicker;

namespace MathMemorizationApp
{
    public partial class MainPage : ContentPage
    {
        public readonly Random rnd = new();
        private string mathProblemText = "";
        private string inputText = "";
        private UIRangePicker? leftNumberRange;
        private UIRangePicker? rightNumberRange;
        private NumberGenerator? numberGenerator;
        private NumberPair? numberPair;
        private bool hasPageLoaded = false;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            pickerOperator.SelectedIndex = 0;

            leftNumberRange = new UIRangePicker(pickerMinNumberLeft, pickerMaxNumberLeft, 100);
            leftNumberRange.handler.ValidationCompleted += PickerChanged;
            
            rightNumberRange = new UIRangePicker(pickerMinNumberRight, pickerMaxNumberRight, 100);
            rightNumberRange.handler.ValidationCompleted += PickerChanged;

            numberGenerator = new NumberGenerator(
                leftNumberRange.GetMinValue(), 
                leftNumberRange.GetMaxValue(), 
                rightNumberRange.GetMinValue(), 
                rightNumberRange.GetMaxValue());
            numberPair = numberGenerator.GetRandomNumberPair();
            labelMath.Text = mathProblemText = UITextHelper.GetMathProblemText(numberPair);
            hasPageLoaded = true;
        }

        private void OnNumpadClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            inputText += clickedButton.Text;
            labelMath.Text = mathProblemText + inputText;
            double correctAnswer = numberPair!.Operate();
            int correctAnswerLength = correctAnswer.ToString().Length;

            if (inputText.Length == correctAnswerLength)
                UpdateScore();
        }

        private void UpdateScore()
        {
            int userInput = Convert.ToInt32(inputText);
            ScoreController.UpdateNumberPairScores(
                numberGenerator!.numberPairs,
                numberPair!,
                userInput,
                out bool userGaveCorrectAnswer);

            if (userGaveCorrectAnswer)
                labelMath.TextColor = Color.FromRgba("#0f0");
            else
                labelMath.TextColor = Color.FromRgba("#f00");

            numberPair = numberGenerator.GetRandomNumberPair();
            inputText = "";
            labelMath.Text = mathProblemText = UITextHelper.GetMathProblemText(numberPair);
        }

        private void OnDelClicked(object sender, EventArgs e)
        {
            if (inputText.Length > 0)
                inputText = inputText[..^1];
            labelMath.Text = mathProblemText + inputText;
        }

        private void PickerChanged()
        {
            ScoreController.operatorMode = (NumberPair.OperatorMode)pickerOperator.SelectedIndex;
            numberGenerator = new NumberGenerator(
                leftNumberRange!.GetMinValue(), 
                leftNumberRange.GetMaxValue(), 
                rightNumberRange!.GetMinValue(),
                rightNumberRange.GetMaxValue());
            numberPair = numberGenerator.GetRandomNumberPair();
            labelMath.Text = mathProblemText = UITextHelper.GetMathProblemText(numberPair);
        }
    }
}
