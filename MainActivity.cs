using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;

namespace ViewProject2
{
	[Activity(Label = "ViewProject2", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		private float textSize = 20;
		private EditText field;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			
			List<int> ids = new List<int>() {Resource.Id.BtBtn,Resource.Id.ItBtn,Resource.Id.NtBtn,Resource.Id.ZItBtn,Resource.Id.ZOtBtn };
			field = FindViewById<EditText>(Resource.Id.editField);
			for (int i = 0; i < ids.Count;i++)
			{
				var button = FindViewById<Button>(ids[i]);
				if (button != null) {
					button.Click += B_Click;
				}
			}
			ImageButton nextPagBtn = FindViewById<ImageButton>(Resource.Id.NpBtn);
			nextPagBtn.Click += (sender, e) => {
				StartActivity(typeof(SecondActivity));
			};			
		}
		
		void B_Click(object sender, System.EventArgs e)
		{
			var view = (View)sender;
			if (view != null) {
				switch (view.Id) {
					case Resource.Id.NtBtn: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
						}
					}break;
					case Resource.Id.ItBtn: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
						}	
					}break;
					case Resource.Id.BtBtn: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
						}
					}break;
					case Resource.Id.ZItBtn: {
						if (textSize <= 72)
							textSize += 2;
						if(field != null)
							field.SetTextSize(Android.Util.ComplexUnitType.Dip,textSize);	
					}break;
					case Resource.Id.ZOtBtn: { 
						if (textSize >= 72)
							textSize -= 2;
						if(field != null)
							field.SetTextSize(Android.Util.ComplexUnitType.Dip,textSize);	
					}break;
				}
			}
		}
	}
}

