using JonKenPo.ViewModel;

namespace JonKenPo.View;

public partial class JonKenPoView : ContentPage
{
	public JonKenPoView()
	{
		InitializeComponent();
		BindingContext = new JonKenPoViewModel();
    }
}