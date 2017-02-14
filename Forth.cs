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
		//for alert dialog
		private const int IDD_EXIT = 0;
		private string[] items = { "rec", "bu","che","kek","lol"};

		//for menu
		private const int IDM_CNTX_OPEN = 111;
		private const int IDM_CNTX_CLOSE = 112;
		
		private const int IDM_OPEN = 101;
		private const int IDM_CLOSE = 102;
		private const int IDM_NEW = 105;
		private const int IDM_WRITE = 106;
		private const int IDM_CLONE = 107;
		private const int IDM_RESET = 108;
		
		private const int IDM_FIND_NEXT = 103;
		private const int IDM_FIND_PREV = 104;
		
		
		
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
			RegisterForContextMenu(FindViewById<LinearLayout>(Resource.Id.myLayout));
		}
		
		public override bool OnCreateOptionsMenu(IMenu menu)
		{

			menu.Add(Menu.None, IDM_OPEN, Menu.None, "Open")
			.SetIcon(Resource.Drawable.abc_ic_menu_cut_mtrl_alpha);
			menu.Add(Menu.None, IDM_CLOSE, Menu.None, "Close")
			.SetIcon(Resource.Drawable.abc_ic_menu_copy_mtrl_am_alpha);

			menu.Add(Menu.None, IDM_NEW, Menu.None, "New");
			menu.Add(Menu.None, IDM_WRITE, Menu.None, "Write");
			menu.Add(Menu.None, IDM_CLONE, Menu.None, "Clone");
			menu.Add(Menu.None, IDM_RESET, Menu.None, "Reset");
			
			menu.Add(Menu.None, IDM_FIND_NEXT, Menu.None, "Find/Next");
			menu.Add(Menu.None, IDM_FIND_PREV, Menu.None, "Find/Previous");
			return base.OnCreateOptionsMenu(menu);
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			string mess = "";
			bool result = false;
			switch (item.ItemId)
			{
				case IDM_OPEN: {
					mess = "OPEN";
					result= true;
				}break;
				case IDM_CLOSE: {
					mess = "CLOSE";
					result= true;
				}break;
				case IDM_NEW: {
					mess = "NEW";
					result= true;
				}break;
				case IDM_WRITE: {
					mess = "WRITE";
					result= true;
				}break;
				case IDM_CLONE: {
					mess = "CLONE";
					result= true;
				}break;
				case IDM_RESET: {
					mess = "RESET";
					result= true;
				}break;
				
				case IDM_FIND_NEXT: {
					mess = "NEXT";
					result= true;
				}break;
				case IDM_FIND_PREV: {
					mess = "PREVIOUS";
					result= true;
				}break;
				default: {
					mess = "";
					result = false;
				}break;
			}

			Toast.MakeText(this, mess, ToastLength.Short).Show();

			return result;
		}
		
		public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
		{			
			ISubMenu sm = menu.AddSubMenu("File");
			sm.Add(Menu.None, IDM_CNTX_OPEN, Menu.None, "Open");
			
			sm.Add(Menu.None, IDM_CNTX_OPEN, Menu.None, "Save");
			
			base.OnCreateContextMenu(menu, v, menuInfo);
		}
		public override bool OnContextItemSelected(IMenuItem item)
		{
			string txt = "";
			switch (item.ItemId)
			{
				case IDM_CNTX_OPEN:{
					txt = "OPEN";
				}break;
				case IDM_CNTX_CLOSE:{
					txt = "CLOSE";
				}break;
				default:
					return false;
			}
			Toast.MakeText(this, txt, ToastLength.Short).Show();
			return true;
			
		}
		
	}
	
}
