using System.Linq;

namespace Sample1Data
{
    public class PlayerService
    {
        private readonly IDataContext _context;

        public PlayerService(IDataContext context)
        {
            _context = context;
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void InititalizeData()
        {
            Player player = new Player()
            {
                Name = "Player1"
            };

            if (_context.Players.Count(p => p.Name == player.Name) == 0)
            {
                _context.Players.Add(player);
            }

            _context.SaveChanges();
        }
    }
}
