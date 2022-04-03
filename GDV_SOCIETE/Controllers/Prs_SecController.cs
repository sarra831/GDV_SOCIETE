using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDV_SOCIETE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Prs_SecController : ControllerBase
    {
        [HttpGet] // ActionResult List for the schemas down blow
        public async Task<ActionResult<List<Prs_Sec>>> Get()
        {
            var perso = new List<Prs_Sec>
            {
                new Prs_Sec
                {
                    CartID = 1,
                    Nom = "Abas",
                    Prenom = "salah"
                }
            };
            return Ok(perso);
        }
       }
    }

