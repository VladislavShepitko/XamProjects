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
			
			List<Button> buts = new List<Button>();
			
			foreach (var b in buts)
			{
				b.Click += B_Click;
			}
		}
		
		void B_Click(object sender, System.EventArgs e)
		{
			var view = (View)sender;
			if (view != null) {
				switch (view.Id) {
					case 0: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
						}
					}break;
					case 1: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
						}	
					}break;
					case 2: {
						if (field != null) {
							field.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
						}
					}break;
					case 3: {
						if (textSize <= 72)
							textSize += 2;
							field.SetTextSize(Android.Util.ComplexUnitType.Dip,textSize);	
					}break;
					case 4: { 
					if (textSize >= 72)
							textSize -= 2;
							field.SetTextSize(Android.Util.ComplexUnitType.Dip,textSize);	
					}break;
				}
			}
		}
	}
}

