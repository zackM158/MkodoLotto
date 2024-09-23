namespace Mkodo.Controls;

public partial class HeaderView : ContentView
{
    public HeaderView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty HasBackButtonProperty =
    BindableProperty.Create(
        nameof(HasBackButton),
        typeof(bool),
        typeof(HeaderView),
        defaultValue: true);

    public bool HasBackButton
    {
        get => (bool)GetValue(HasBackButtonProperty);
        set => SetValue(HasBackButtonProperty, value);
    }

}
