using learn_v2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learn_v2.Models
{
    public class PlayerRepository
    {
        private readonly MySqlDapper mySqlDapper;
        public PlayerRepository(MySqlDapper _mySqlDapper)
        {
            mySqlDapper = _mySqlDapper;
        }
        public List<PlayerModel> GetPlayerList()
        {
            return mySqlDapper.Query<PlayerModel>("SELECT * FROM player").ToList();
        }
        public PlayerModel GetPlayer(int id)
        {
            return mySqlDapper.ExecuteProcedure<PlayerModel>("SelectPlayerNameById", new { Id = id }).Single();
        }
        public PlayerModel CreatePlayer(string name)
        {
            return mySqlDapper.ExecuteProcedure<PlayerModel>("PlayerInsert", new { playerName = name }).Single();
        }
    }
}
