﻿using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using StarWarsSample.Core.ViewModels;
using Xamarin.Forms;

namespace StarWarsSample.Forms.UI.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = false)]
	public partial class PersonPage : MvxContentPage<PersonViewModel>
	{
        private bool _showing = false;

		public PersonPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _showing = true;

            await AnimateButton();
        }

        protected override void OnDisappearing()
        {
            _showing = false;

            base.OnDisappearing();

            ViewModel.CloseCompletionSource.TrySetResult(false);
        }

        private async Task AnimateButton()
        {
            while(_showing)
            {
                await ViewExtensions.ScaleTo(Destroy, 1.1d, 600);
                await ViewExtensions.ScaleTo(Destroy, 0.9d, 600);
            }
        }
    }
}