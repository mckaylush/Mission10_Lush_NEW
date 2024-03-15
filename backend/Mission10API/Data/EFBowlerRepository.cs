using Microsoft.EntityFrameworkCore;

namespace Mission10API.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlingLeagueContext _bowlerContext;
        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _bowlerContext = temp;
        }
        public IEnumerable<Bowler> Bowlers => _bowlerContext.Bowlers;

        public IEnumerable<Bowler> GetBowlersByTeams(params string[] teamNames)
        {
            return _bowlerContext.Bowlers
                .Include(b => b.Team) // Ensure Team data is included
                .Where(b => teamNames.Contains(b.Team.TeamName)) // Filter by team names
                .ToList();
        }
    }
}
