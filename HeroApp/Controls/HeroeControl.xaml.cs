using HeroApp.Models.Entities;

namespace HeroApp.Controls;

public partial class HeroeControl : StackLayout
{
	public HeroeControl()
	{
		InitializeComponent();
	}

    #region Bindable Properties

    public static readonly BindableProperty HeroeNameProperty = BindableProperty.Create(
        nameof(HeroeName),
        typeof(string),
        typeof(HeroeControl)
        );

    public static readonly BindableProperty HeroeIdProperty = BindableProperty.Create(
    nameof(HeroeId),
    typeof(int),
    typeof(HeroeControl)
    );

    public static readonly BindableProperty HeroeImageProperty = BindableProperty.Create(
    nameof(HeroeImage),
    typeof(string),
    typeof(HeroeControl)
    );

    #endregion

    #region [Properties]

    public string HeroeName
    {
        get => (string)this.GetValue(HeroeNameProperty);
        set => this.SetValue(HeroeNameProperty, value);
    }

    public int HeroeId
    {
        get => (int)this.GetValue(HeroeIdProperty);
        set => this.SetValue(HeroeIdProperty, value);
    }

    public string HeroeImage
    {
        get => (string)this.GetValue(HeroeImageProperty);
        set => this.SetValue(HeroeImageProperty, value);
    }
    #endregion
}