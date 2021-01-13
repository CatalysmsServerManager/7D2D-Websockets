using System;
using CSMM_WSServer;

public static class Injections
{
    public static WSServer ws = new WSServer();
    public static void Log_Postfix(String _s)
    {
        ws.instance.WebSocketServices.Broadcast(_s);
    }
}