using System;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Bot.Connector.DirectLine;
using Activity = Android.App.Activity;

namespace Android_App
{
    [Activity(Label = "Bot1", MainLauncher = true, Icon = "@drawable/Bot")]
    public class MainActivity : Activity
    {
        const string DL_SECRET = "itWhFDgDEpg.cwA.dr0.DtqD39aMRUzFnwplhP_tHWtbMEmYC5sY2axq0pb9Z0Y";
        const string BOT_ID = "FooBarBot";
        const string MSFT_APP_ID = "49819cfc-f896-4d98-8eee-9c2229ff2ee1";
        const string MSFT_APP_PWD = "mSpCf5gtNbCtW8eybB24j5C";
        const string FROM_USER = "Default User";

        private DirectLineClient directLineClient = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            directLineClient = new DirectLineClient(DL_SECRET);

            var btnTalk = FindViewById<Button>(Resource.Main.btnTalk);
            btnTalk.Click += BtnTalkOnClick;
        }

        private async void BtnTalkOnClick(object Sender, EventArgs Args)
        {
            // code here to call to DirectLine and get show the message
            var botText = FindViewById<TextView>(Resource.Main.botText);
            var errText = FindViewById<TextView>(Resource.Main.errText);

            var connectivity = (ConnectivityManager)GetSystemService(ConnectivityService);
            if (connectivity.ActiveNetworkInfo == null)
            {
                errText.Text = "Please connect to the internet to use this application";
                return;
            }

            var connected = connectivity.ActiveNetworkInfo.IsConnected;
            
            if (!connected)
            {
                errText.Text = "Please connect to the internet to use this application";
                return;
            }

            if (directLineClient == null)
            {
                botText.Text = "Could Not Send Messages - FooBar Bot is offline.";
                return;
            }

            //var conversation = directLineClient.Conversations.StartConversationAsync();

        }
    }
}

