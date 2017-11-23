﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Valentuna.Fragments;

namespace Valentuna
{
    [Activity(Label = "AdddeviceActivity")]
    public class AdddeviceActivity : AppCompatActivity 
    {
        private const int AutoDiscoverDialog = 1;
        private const int DeviceManualDialog = 2;
        EditText CamIPAddresstxt;
        EditText CamIPPorttxt;
        EditText CamUsernametxt;
        EditText CamPasswordtxt;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*etContentView(Resource.Layout.DevHomeFrag);*/


            //var listDialogButton = FindViewById<Button>(Resource.Id.btnAutoDiscoverDevice);
            //listDialogButton.Click += delegate { ShowDialog(AutoDiscoverDialog); };

            //var addDeviceManualButton = FindViewById<Button>(Resource.Id.btnAddDeviceManual);
            //addDeviceManualButton.Click += delegate { ShowDialog(DeviceManualDialog); };

            //CamLoginbtn = FindViewById<Button>(Resource.Id.CamLoginbtn);

            int pos = Intent.GetIntExtra("buttonClicked",0);
            if (pos == 1)
            {
                ShowDialog(AutoDiscoverDialog);
            }
            else
            if (pos == 2)
            {
                ShowDialog(DeviceManualDialog);
            }



        }

        protected override Dialog OnCreateDialog(int id, Bundle args)
        {
            switch (id)
            {
                case AutoDiscoverDialog:
                    {
                        var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        builder.SetIconAttribute(Android.Resource.Attribute.AlertDialogIcon);
                        builder.SetTitle(Resource.String.list_dialog_title);
                        builder.SetSingleChoiceItems(Resource.Array.list_dialog_items, 0, ListClicked);

                        builder.SetPositiveButton(Resource.String.dialog_login, OkClicked);
                        builder.SetNegativeButton(Resource.String.dialog_cancel, CancelClicked);

                        return builder.Create();
                    }
                case DeviceManualDialog:
                    {
                        var customView = LayoutInflater.Inflate(Resource.Layout.AddDeviceManualDialog, null);

                        var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        builder.SetView(customView);
                        builder.SetPositiveButton(Resource.String.dialog_login, OkClicked);
                        builder.SetNegativeButton(Resource.String.dialog_cancel, CancelClicked);

                        return builder.Create();
                    }
            }

            return base.OnCreateDialog(id, args);
        }
        private void OkClicked(object sender, DialogClickEventArgs args)
        {
            var dialog = (Android.Support.V7.App.AlertDialog)sender;
            CamIPAddresstxt = (EditText)dialog.FindViewById(Resource.Id.CamIPAddresstxt);
            CamIPPorttxt = (EditText)dialog.FindViewById(Resource.Id.CamIPPorttxt);
            CamUsernametxt = (EditText)dialog.FindViewById(Resource.Id.CamUsernametxt);
            CamPasswordtxt = (EditText)dialog.FindViewById(Resource.Id.CamPasswordtxt);

            if (null != Convert.ToString(CamIPAddresstxt.Text) || null != Convert.ToString(CamIPPorttxt.Text) || null != Convert.ToString(CamUsernametxt.Text) || null != Convert.ToString(CamPasswordtxt.Text))
            {
                Toast.MakeText(this, Resource.String.login_success, ToastLength.Short).Show();
                //var myExhibitHistoryActivity = new Intent(Activity, typeof(LivePlay));
                //StartActivity(LivePlay);
            }
            else
            {
                Toast.MakeText(this, Resource.String.login_failed, ToastLength.Short).Show();
            }
                //Toast.MakeText(this, (username != null ?
                //    string.Format("Username: {0} ", username.Text) : "") +
                //    (password != null ? string.Format("Password: {0}", password.Text) : ""), ToastLength.Short).Show();

        }

        private void CancelClicked(object sender, DialogClickEventArgs args)
        {
            DevHome.NewInstance();
        }

        private void ListClicked(object sender, DialogClickEventArgs args)
        {
            var items = Resources.GetStringArray(Resource.Array.list_dialog_items);

            Toast.MakeText(this, string.Format("You've selected: {0}, {1}", args.Which, items[args.Which]), ToastLength.Short).Show();
        }

    }
}