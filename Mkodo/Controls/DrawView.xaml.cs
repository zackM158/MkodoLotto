namespace Mkodo.Controls;

public partial class DrawView : ContentView
{
    public DrawView()
    {
        InitializeComponent();
        this.SizeChanged += OnSizeChanged!;
    }


    private async void OnSizeChanged(object sender, EventArgs e)
    {
        this.SizeChanged -= OnSizeChanged!;
        await AnimateNumbers();
    }

    private async Task AnimateNumbers()
    {
        var numberBalls = NumbersLayout!.Children;

        for (int i = 0; i < numberBalls.Count; i++)
        {
            var numberBorder = numberBalls[i] as Border;
            numberBorder!.TranslationX = -500;
            numberBorder.Rotation =-180;
        }

        BonusBall!.TranslationX = -500;
        BonusBall.Rotation = -180;

        for (int i = 0; i < numberBalls.Count; i++)
        {
            var numberBall = numberBalls[i] as Border;

            var translateTask = numberBall!.TranslateTo(0, 0, 300, Easing.CubicInOut);
            var rotateTask = numberBall!.RotateTo(0, 500, Easing.CubicInOut);
            await Task.WhenAll(translateTask, rotateTask);
        }

        var translateBonusTask = BonusBall!.TranslateTo(0, 0, 300, Easing.CubicInOut);
        var rotateBonusTask = BonusBall!.RotateTo(0, 500, Easing.CubicInOut);
        await Task.WhenAll(translateBonusTask, rotateBonusTask);
    }
}
