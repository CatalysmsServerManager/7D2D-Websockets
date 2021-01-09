using System.Collections.Generic;
using System.Text;

namespace sdtd_apimod
{

    public class API : IModApi
    {
        public void InitMod()
        {
            //ModEvents.GameStartDone.RegisterHandler(GameAwake);
            //ModEvents.GameShutdown.RegisterHandler(GameShutdown);
            //ModEvents.SavePlayerData.RegisterHandler(SavePlayerData);
            //ModEvents.PlayerSpawnedInWorld.RegisterHandler(PlayerSpawnedInWorld);
            //ModEvents.PlayerDisconnected.RegisterHandler(PlayerDisconnected);
            //ModEvents.ChatMessage.RegisterHandler(ChatMessage);
            //ModEvents.PlayerLogin.RegisterHandler(PlayerLogin);
            //ModEvents.EntityKilled.RegisterHandler(EntityKilled);
            //ModEvents.GameMessage.RegisterHandler(GameMessage);
            //ModEvents.CalcChunkColorsDone.RegisterHandler(CalcChunkColorsDone);
            

            Log.Out("Bla bla");
        }

        private bool GameMessage(ClientInfo _cInfo, EnumGameMessages _type, string _msg, string _mainName, bool _localizeMain, string _secondaryName, bool _localizeSecondary)
        {
            
            return true;
        }

        private void GameAwake()
        {
            
        }

        private void GameShutdown()
        {
            
        }

        private void PlayerDisconnected(ClientInfo _cInfo, bool _bShutdown)
        {
            
        }

        private void EntityKilled(Entity entKilled, Entity entOffender)
        {
            
        }

        private void PlayerSpawnedInWorld(ClientInfo _cInfo, RespawnType _respawnReason, Vector3i _pos)
        {
            
        }

        private void SavePlayerData(ClientInfo _cInfo, PlayerDataFile _playerDataFile)
        {
            
        }

        private bool PlayerLogin(ClientInfo _cInfo, string _compatibilityVersion, StringBuilder sb)
        {
            
            return true;
        }

        private bool ChatMessage(ClientInfo _cInfo, EChatType _type, int _senderId, string _msg, string _mainName, bool _localizeMain, List<int> _recipientEntityIds)
        {
            
            return true;
        }

        private void CalcChunkColorsDone(Chunk _chunk)
        {
            
        }
    }
}

