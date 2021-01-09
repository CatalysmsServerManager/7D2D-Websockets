using System;
using System.Collections.Generic;
using sdtd_apimod;


public static class Injections
{
    public static void Log_Postfix(String _s)
    {
        Log.Out("Ayyyyy we made it");
    }
}