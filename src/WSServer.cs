using WebSocketSharp;
using WebSocketSharp.Server;
using WebSocketSharp.Net;
using AllocsFixes.NetConnections.Servers.Web;
namespace CSMM_WSServer
{
    public class WSServer : WebSocketBehavior
    {
        public WSServer()
        {
            this.Start();
        }
        public WebSocketServer instance;
        public void Start()
        {
            int webPort = GamePrefs.GetInt(EnumUtils.Parse<EnumGamePrefs>("ControlPanelPort"));
            instance = new WebSocketServer("ws://0.0.0.0:" + (webPort + 5));
            instance.AddWebSocketService<Logs>("/log");

            instance.AuthenticationSchemes = AuthenticationSchemes.Basic;
            instance.Realm = "WebSocket 7D2D";
            WebPermissions.AdminToken[] tokens = WebPermissions.Instance.GetAdmins();
            instance.UserCredentialsFinder = id =>
           {
               // Idk, there's no .Find here so I just iterate through
               // Probably a cleaner solution possible but ¯\_(ツ)_/¯
               foreach (WebPermissions.AdminToken token in tokens)
               {
                   if (token.name == id.Name && token.permissionLevel == 0)
                   {
                       return new NetworkCredential(id.Name, token.token, "WebSocket 7D2D");
                   }
               }

               instance.Log.Error($"Tried to authenticate with invalid token {id.Name}");
               return null;
           };

            instance.Start();
        }
    }

    public class Logs : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Send("PONG");
        }
    }
}