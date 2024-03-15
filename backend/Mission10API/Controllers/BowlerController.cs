using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10API.Data;
using System.Linq;


namespace Mission10API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository { get; set; }
        public BowlerController(IBowlerRepository temp)
        {

            _bowlerRepository = temp;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BowlerDto>> Get()
        {
            var bowlerData = _bowlerRepository.GetBowlersByTeams("Marlins", "Sharks")
                                .Select(b => new BowlerDto
                                {
                                    FullName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}".Trim(),
                                    TeamName = b.Team.TeamName, // Assuming Team is properly included and not null
                                    BowlerAddress = b.BowlerAddress,
                                    BowlerCity = b.BowlerCity,
                                    BowlerState = b.BowlerState,
                                    BowlerZip = b.BowlerZip,
                                    BowlerPhoneNumber = b.BowlerPhoneNumber
                                })
                                .ToArray();

            return Ok(bowlerData);
        }
        public class BowlerDto
        {
            public string FullName { get; set; }
            public string TeamName { get; set; }
            public string BowlerAddress { get; set; }
            public string BowlerCity { get; set; }
            public string BowlerState { get; set; }
            public string BowlerZip { get; set; }
            public string BowlerPhoneNumber { get; set; }
        }
    }
}
