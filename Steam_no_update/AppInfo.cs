using SteamKit2;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SteamKit2.Internal.CContentBuilder_CommitAppBuild_Request;

namespace Steam_no_update
{
    class AppInfo
    {


        // Beat Saber's app id
        public static uint APPID = 0;
        public static uint[] DEPOT_ID;

        private static SteamClient steamClient;
        private static SteamApps steamApps;
        private static SteamUser steamUser;
        private static CallbackManager manager;

        private static bool isRunning = true;

        private static JobID infoRequest = JobID.Invalid;
        private static string manifestId = string.Empty;

        public async Task<string> TryRetrieve(string aPPID, string dEPOT_ID)
        {
            manifestId = string.Empty;
            APPID = (uint)int.Parse(aPPID);
            if (dEPOT_ID.Contains(','))
            {
                string tempDepots = dEPOT_ID;
                DEPOT_ID = new uint[dEPOT_ID.ToCharArray().Count(c => c == ',') + 1];
                for (int i = 0; i < DEPOT_ID.Length; i++)
                {
                    int index = tempDepots.IndexOf(",");
                    DEPOT_ID[i] = (uint)int.Parse(tempDepots.Substring(0,index));
                    tempDepots = tempDepots.Substring((index + 1));
                    if (i == DEPOT_ID.Length - 2)
                        DEPOT_ID[++i] = (uint)int.Parse(tempDepots);
                }
            }
            else
            {
                DEPOT_ID = new uint[1];
                DEPOT_ID[0] = (uint)int.Parse(dEPOT_ID);
            }


            // initialize a client and a callback manager for responding to events
            steamClient = new SteamClient();
            manager = new CallbackManager(steamClient);

            // get a handler and register to callbacks we are interested in
            steamUser = steamClient.GetHandler<SteamUser>();
            steamApps = steamClient.GetHandler<SteamApps>();
            manager.Subscribe<SteamApps.PICSProductInfoCallback>(OnProductInfo);
            manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
            manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
            manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);

            isRunning = true;

            await Task.Run(() => {
                Debug.WriteLine("Connecting to Steam...");

                steamClient.Connect();

                while (isRunning)
                    manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            });
            if (!string.IsNullOrEmpty(manifestId))
                return manifestId.Substring(0, manifestId.Length - 1);//[..^1];
            else return string.Empty;
        }


        static void OnConnected(SteamClient.ConnectedCallback callback)
        {
            Debug.WriteLine("Successfully connected to Steam");
            // log on anonymously
            steamUser.LogOnAnonymous();
        }

        static void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            Debug.WriteLine("Disconnected from Steam");
            isRunning = false;
        }

        static void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                if (callback.Result == EResult.AccountLogonDenied)
                {
                    // this shouldn't happen when logging in anonymously
                    Debug.WriteLine("Unable to login to Steam");
                    isRunning = false;
                    return;
                }
                // if there is another error
                Debug.WriteLine("Unable to login to Steam: {0} / {1}", callback.Result, callback.ExtendedResult);
                isRunning = false;
                return;
            }

            Debug.WriteLine("Successfully logged in to Steam");

            // request product info
            infoRequest = steamApps.PICSGetProductInfo(APPID, null);
        }

        private void OnProductInfo(SteamApps.PICSProductInfoCallback callback)
        {
            Debug.WriteLine("In OnProductInfo callback");
            if (callback.JobID != infoRequest)
                return;
            string manifest = string.Empty;

            // not sure if this is game specific or applies to other games
            foreach (uint depot in DEPOT_ID)
                try
                {
                    manifest = callback?.Apps[APPID]?.KeyValues.Children
        .FirstOrDefault(x => x.Name == "depots")?.Children
        .FirstOrDefault(x => x.Name == depot.ToString())?.Children
        .FirstOrDefault(x => x.Name == "manifests")?.Children
        .FirstOrDefault(x => x.Name == "public")?.Value;

                    if (manifest?.Length >= 16)
                        manifestId += manifest + ",";

                    Debug.WriteLine(manifestId);
                }
                catch {  }//sometimes even though the callback.JobID is the same, it comes in multiples, dont know why tho

            // log off after getting the manifest(s)
            steamUser.LogOff();
        }

        static void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            Debug.WriteLine("Logged off Steam: {0}", callback.Result);
            isRunning = false;
        }

    }
}
