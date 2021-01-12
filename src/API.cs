using System;
using System.Reflection;
using HarmonyLib;

namespace sdtd_apimod
{
    public class API : IModApi
    {
        public void InitMod()
        {
            ModEvents.GameStartDone.RegisterHandler(GameStartDone);
            ModEvents.GameShutdown.RegisterHandler(GameShutdown);
        }

        private void GameStartDone()
        {
            try
            {
                CSMMLog.Out("Runtime patching initialized");
                Harmony harmony = new Harmony("com.github.CSMM");
                Type[] logTypes = { typeof(string) };
                MethodInfo original = AccessTools.Method(typeof(Log), "Out", logTypes);
                if (original == null)
                {
                    CSMMLog.Out("Injection failed: Log#Out method was not found");
                }
                else
                {
                    MethodInfo postfix = typeof(Injections).GetMethod("Log_Postfix");
                    if (postfix == null)
                    {
                        CSMMLog.Out("Injection failed: Log#Out postfix not found");
                        return;
                    }
                    harmony.Patch(original, null, new HarmonyMethod(postfix));
                    CSMMLog.Out("Injected Log#Out");

                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                // now look at ex.LoaderExceptions - this is an Exception[], so:
                foreach (Exception inner in ex.LoaderExceptions)
                {
                    // write details of "inner", in particular inner.Message
                    CSMMLog.Out(inner.Message);
                }
            }

        }

        private void GameShutdown()
        {
            // Shut down the websocket server
        }

    }

    public class CSMMLog
    {
        public static void Out(String msg)
        {
            Log.Out("[CSMM WS] " + msg);
        }
    }
}

