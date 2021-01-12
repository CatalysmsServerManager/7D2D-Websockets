using System;
using System.Reflection;
using HarmonyLib;

namespace sdtd_apimod
{
    public class API : IModApi
    {
        public void InitMod()
        {
            Log.Out("[CSMM WS] Runtime patching initialized");
            Harmony harmony = new Harmony("com.github.CSMM");
            Type[] logTypes = { typeof(string) };
            MethodInfo original = AccessTools.Method(typeof(Log), "Out", logTypes);
            if (original == null)
            {
                Log.Out("[CSMM WS] Injection failed: Log#Out method was not found");
            }
            else
            {
                MethodInfo postfix = typeof(Injections).GetMethod("Log_Postfix");
                if (postfix == null)
                {
                    Log.Out("[CSMM WS] Injection failed: Log#Out postfix not found");
                    return;
                }
                harmony.Patch(original, null, new HarmonyMethod(postfix));
                Log.Out("[CSMM WS] Injected Log#Out");

            }
        }
    }
}

