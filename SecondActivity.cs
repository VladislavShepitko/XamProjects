// SecondActivity.cs
// Vladyslav Shepitko
// 12.02.2017

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
	[Activity(Label = "SecondActivity")]
	public class SecondActivity : Activity
	{
		private bool isPlaying = true;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Second);
			var group1 = FindViewById<RadioGroup>(Resource.Id.group1);
			for (int i = 0; i < group1.ChildCount; i++) {
				var rb = group1.GetChildAt(i);
				rb.Click += Arg_Click;
			}
			var playBtn = FindViewById<ImageButton>(Resource.Id.img1);
			playBtn.Click += (sender, e) => {
				if (isPlaying) {
					playBtn.SetImageResource(Resource.Drawable.abc_ic_clear_mtrl_alpha);
				}
				else {
					playBtn.SetImageResource(Resource.Drawable.abc_ic_commit_search_api_mtrl_alpha);
				}
				isPlaying = !isPlaying;
				StartActivity(typeof(ThirdActivity));	
			};
		}
		void Arg_Click(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Console.WriteLine("" + rb.Text);
		}
	}
}
