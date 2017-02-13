// ThirdActivity.cs
// Vladyslav Shepitko
// 12.02.2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ViewProject2
{
	[Activity(Label = "ThirdActivity")]
	public class ThirdActivity : Activity, SeekBar.IOnSeekBarChangeListener
	{
		private int speed = 1;
		private bool isRunning = true;
		TextView v;
		Action onFinish;
		ProgressBar pb;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Third);
			
			Button startBtn = FindViewById<Button>(Resource.Id.startBtn);
			startBtn.Click += StartBtn_Click;
			Button stopBtn = FindViewById<Button>(Resource.Id.stopBtn);
			stopBtn.Click += StopBtn_Click;
			
			pb = FindViewById<ProgressBar>(Resource.Id.pb1);
			SeekBar sb = FindViewById<SeekBar>(Resource.Id.seekBar);
			v = FindViewById<TextView>(Resource.Id.infoTxt);
			sb.SetOnSeekBarChangeListener(this);
			pb.Max = 100;

			onFinish += () => {
				var view = LayoutInflater.Inflate(Resource.Layout.Forth, null);
				var info = view.FindViewById<TextView>(Resource.Id.toastText);
				info.Text = "Lol kek cheburec!";
				Toast t = new Toast(this);
				t.View = view;
				t.Duration = ToastLength.Short;
				//t.SetGravity(GravityFlags.Center,0,0);
				t.Show();
				StartActivity(typeof(Forth));
			};			
		}

		public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			//throw new NotImplementedException();
			RunOnUiThread(() => { v.Text = string.Format("speed: {0}", progress); });
		}

		public void OnStartTrackingTouch(SeekBar seekBar)
		{
			//throw new NotImplementedException();
		}

		public void OnStopTrackingTouch(SeekBar seekBar)
		{
			speed = seekBar.Progress;
		}
		
		void StartBtn_Click(object sender, EventArgs e)
		{
			Thread tn = new Thread(() => {
				while (isRunning) {
					try {
						Thread.Sleep(1000);
						RunOnUiThread(() => {
							pb.Progress += speed;
							if (pb.Progress >= 100) {
								isRunning = false;
								if (onFinish != null) {
									onFinish.Invoke();
								}
							}
						});
					}
					catch (ThreadInterruptedException ex) {
						Console.WriteLine(ex.Message);
					}
				}
			});
			isRunning = true;
			tn.Start();
		}
		void StopBtn_Click(object sender, EventArgs e) {
			isRunning = false;
			pb.Progress = 0;
			if (onFinish != null) {
				onFinish.Invoke();
			}
		}
	}
}
