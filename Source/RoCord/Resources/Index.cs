namespace RoCord
{
    class Index
    {
        public static string NewToken;
        public static string Logo = "https://cdn.discordapp.com/attachments/1013411507125628939/1014843697990479872/unknown.png";
        public static string Icon = "https://cdn.discordapp.com/attachments/1013513362606407765/1023238850182647909/RoCordIcon.png";
        public static string VMP = "https://cdn.discordapp.com/attachments/990045851768475730/1015656173078335488/VMProtectSDK32.dll";
        public static string GitHub = "https://github.com/eb-06/RoCord";
        public static string WeAreDevs = "https://wearedevs.net";
        public static string ScriptsDirectory = "scripts/";
        public static string AutoExecuteDirectory = "autoexec/";
        public static string FileToBig = "```lua\n-- File is to big to view.\n```";
        public static string ConsoleLogo = @"    ____          ______                  __
   / __ \ ____   / ____/____   _____ ____/ /
  / /_/ // __ \ / /    / __ \ / ___// __  / 
 / _, _// /_/ // /___ / /_/ // /   / /_/ /  
/_/ |_| \____/ \____/ \____//_/    \__,_/ Loaded!";
        public static string LuaSyntax(string Text) { return $"```lua\n{Text}\n```"; }

        public static void DownloadVMP() { 
            using (var WebClient = new System.Net.WebClient())
                WebClient.DownloadFile(VMP, "VMProtectSDK32.dll"); 
        }
    }
}