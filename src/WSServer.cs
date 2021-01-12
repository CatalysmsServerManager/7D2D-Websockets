using WebSocketSharp;
using WebSocketSharp.Server;

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
            instance = new WebSocketServer("ws://0.0.0.0:8084");
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