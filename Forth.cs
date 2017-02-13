// Forth.cs
// Vladyslav Shepitko
// 13.02.2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ViewProject2
{
	[Activity(Label = "Forth")]
	public class Forth : Activity
	{
		private const int IDD_EXIT = 0;
		private string[] items = { "rec", "bu","che","kek","lol"};
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Fifth);
			var dialogBtn = FindViewById<Button>(Resource.Id.dialogBtn);
			dialogBtn.Click += (sender, e) => {
				View view = LayoutInflater.Inflate(Resource.Layout.Dialog, null);
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.SetView(view);
				builder.SetPositiveButton("Hop", (s, ee) => {});
				builder.Create().Show();
			};
		}
		
		
	}
	
}
