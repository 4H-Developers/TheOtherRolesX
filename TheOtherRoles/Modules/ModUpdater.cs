using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using Il2CppSystem;
using Hazel;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnhollowerBaseLib;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Twitch;

namespace TheOtherRoles.Modules {
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class ModUpdaterButton {
        private static void Prefix(MainMenuManager __instance) {
            CustomHatLoader.LaunchHatFetcher();
            ModUpdater.LaunchUpdater();
            if (!ModUpdater.hasUpdate) return;
            var template = GameObject.Find("ExitGameButton");
            if (template == null) return;

            var button = UnityEngine.Object.Instantiate(template, null);
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y + 0.6f, button.transform.localPosition.z);

            PassiveButton passiveButton = button.GetComponent<PassiveButton>();
            passiveButton.OnClick = new Button.ButtonClickedEvent();
            passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)onClick);
            
            var text = button.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                text.SetText("更多职业\n更新可用");
            })));

            TwitchManager man = DestroyableSingleton<TwitchManager>.Instance;
            ModUpdater.InfoPopup = UnityEngine.Object.Instantiate<GenericPopup>(man.TwitchPopup);
            ModUpdater.InfoPopup.TextAreaTMP.fontSize *= 0.7f;
            ModUpdater.InfoPopup.TextAreaTMP.enableAutoSizing = false;

            void onClick() {
                ModUpdater.ExecuteUpdate();
                button.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.UpdateAnnounceText))]
    public static class Announcement {
        public static bool Prefix(AnnouncementPopUp __instance) {       
            var text = __instance.AnnounceTextMeshPro;
            text.text = ModUpdater.announcement;
            return false;
        }
    }

    public class ModUpdater { 
        public static bool running = false;
        public static bool hasUpdate = false;
        public static string updateURI = null;
        private static Task updateTask = null;
        public static string announcement = "";
        public static GenericPopup InfoPopup;

        public static void LaunchUpdater() {
            if (running) return;
            running = true;
            checkForUpdate().GetAwaiter().GetResult();
            clearOldVersions();
            if (hasUpdate || TheOtherRolesPlugin.ShowPopUpVersion.Value != TheOtherRolesPlugin.VersionString) {
                DestroyableSingleton<MainMenuManager>.Instance.Announcement.gameObject.SetActive(true);
                TheOtherRolesPlugin.ShowPopUpVersion.Value = TheOtherRolesPlugin.VersionString;
            }
        }

        public static void ExecuteUpdate() {
            string info = "正在更新\n请稍等...";
            ModUpdater.InfoPopup.Show(info); // Show originally
            if (updateTask == null) {
                if (updateURI != null) {
                    updateTask = downloadUpdate();
                } else {
                    info = "自动更新失败\n请手动更新";
                }
            } else {
                info = "您可能\n已经更新了";
            }
            ModUpdater.InfoPopup.StartCoroutine(Effects.Lerp(0.01f, new System.Action<float>((p) => { ModUpdater.setPopupText(info); })));
        }
        
        public static void clearOldVersions() {
            try {
                DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(Application.dataPath) + @"\BepInEx\plugins");
                string[] files = d.GetFiles("*.old").Select(x => x.FullName).ToArray(); // Getting old versions
                foreach (string f in files)
                    File.Delete(f);
            } catch (System.Exception e) {
                System.Console.WriteLine("在清理旧版本时发生错误:\n" + e);
            }
        }

        public static async Task<bool> checkForUpdate() {
            try {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "TheOtherRoles Updater");
                var response = await http.GetAsync(new System.Uri("https://api.github.com/repos/fivefirex/TheOtherRolesX/releases/latest"), HttpCompletionOption.ResponseContentRead);
                // var response = await http.GetAsync(new System.Uri("https://api.github.com/repos/Eisbison/TheOtherRoles/releases/latest"), HttpCompletionOption.ResponseContentRead);
                // var response = await http.GetAsync(new System.Uri("https://api.github.com/repos/EoF-1141/TheOtherRoles/releases/latest"), HttpCompletionOption.ResponseContentRead);
                if (response.StatusCode != HttpStatusCode.OK || response.Content == null) {
                    System.Console.WriteLine("服务器未返回任何数据 " + response.StatusCode.ToString());
                    return false;
                }
                string json = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);
                
                string tagname = data["tag_name"]?.ToString();
                if (tagname == null) {
                    return false; // Something went wrong
                }

                string changeLog = data["body"]?.ToString();
                if (changeLog != null) announcement = changeLog;
                // check version
                System.Version ver = System.Version.Parse(tagname.Replace("v", ""));
                int diff = TheOtherRolesPlugin.Version.CompareTo(ver);
                if (diff < 0) { // Update required
                    hasUpdate = true;
                    announcement = $@"<size=150%>一个新的<color=#FC0303>更多职业</color>
版本{ver}现在可用</size>

{announcement}";

                    JToken assets = data["assets"];
                    if (!assets.HasValues)
                        return false;

                    for (JToken current = assets.First; current != null; current = current.Next) {
                        string browser_download_url = current["browser_download_url"]?.ToString();
                        if (browser_download_url != null && current["content_type"] != null) {
                            if (current["content_type"].ToString().Equals("application/x-msdownload") &&
                                browser_download_url.EndsWith(".dll")) {
                                updateURI = browser_download_url;
                                return true;
                            }
                        }
                    }
                }  else {
                    announcement = $@"<size=150%><color=#FC0303>更多职业</color>版本{ver}:</size>

{announcement}";
                }
            } catch (System.Exception ex) {
                TheOtherRolesPlugin.Instance.Log.LogError(ex.ToString());
                System.Console.WriteLine(ex);
            }
            return false;
        }

        public static async Task<bool> downloadUpdate() {
            try {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "TheOtherRoles Updater");
                var response = await http.GetAsync(new System.Uri(updateURI), HttpCompletionOption.ResponseContentRead);
                if (response.StatusCode != HttpStatusCode.OK || response.Content == null) {
                    System.Console.WriteLine("服务器未返回任何数据: " + response.StatusCode.ToString());
                    return false;
                }
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                System.UriBuilder uri = new System.UriBuilder(codeBase);
                string fullname = System.Uri.UnescapeDataString(uri.Path);
                if (File.Exists(fullname + ".old")) // Clear old file in case it wasnt;
                    File.Delete(fullname + ".old");

                File.Move(fullname, fullname + ".old"); // rename current executable to old

                using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                    using (var fileStream = File.Create(fullname)) { // probably want to have proper name here
                        responseStream.CopyTo(fileStream); 
                    }
                }
                showPopup("更多职业\n更新成功\n重启游戏以体验");
                return true;
            } catch (System.Exception ex) {
                TheOtherRolesPlugin.Instance.Log.LogError(ex.ToString());
                System.Console.WriteLine(ex);
            }
            showPopup("更多职业\n更新失败\n请稍后重试或手动更新");
            return false;
        }
        private static void showPopup(string message) {
            setPopupText(message);
            InfoPopup.gameObject.SetActive(true);
        }

        public static void setPopupText(string message) {
            if (InfoPopup == null)
                return;
            if (InfoPopup.TextAreaTMP != null) {
                InfoPopup.TextAreaTMP.text = message;
            }
        }
    }
}