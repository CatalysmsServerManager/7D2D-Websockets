using WebSocketSharp;
using WebSocketSharp.Server;
using sdtd_apimod;
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
            instance = new WebSocketServer("ws://0.0.0.0:" + (webPort + 4));
            instance.AddWebSocketService<Log>("/log");
            instance.Start();
        }
    }

    public class Log : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Send("PONG");
        }
    }
}