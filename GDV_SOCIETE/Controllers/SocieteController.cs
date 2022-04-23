using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDV_SOCIETE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocieteController : ControllerBase
    { 
        public DataContext Context { get; }

        //constrecteur 
        public SocieteController(DataContext context)
        {
            Context = context;
        }   

        //read methode, methode lire 
        [HttpGet]
        public async Task<ActionResult<List<Societe>>> Get()
        {
            //cet ligne returns le profile creer , avec le base de dennees "societes" est le nom du tableau dans le base 
            return Ok( await Context.societes.ToListAsync());

        }
        //Recherche par ID affichage l'element avec le id donner 
        [HttpGet("{id}")]
        public async Task<ActionResult<Societe>> Get(int id )
        {
            //var societe = Nsociete.Find(h => h.Id == id); sans conextion avec le base de donnes
                var societe = await Context.societes.FindAsync(id); // recherche par ID ! 
                if (societe == null)
                    return BadRequest("N'existe pas !");
            //cet ligne returns le variable creer 
            return Ok(societe);

        }
        //create methode , mothode creation 
        [HttpPost]
        public async Task<ActionResult<List<Societe>>> AddSocietes(Societe societe)
         {
            //creation de societe 
            Context.societes.Add(societe);
            await Context.SaveChangesAsync();
           return Ok( await Context.societes.ToListAsync());
        }
        //modifier 
        [HttpPut]
        public async Task<ActionResult<List<Societe>>> UpdateSocietes(Societe request)
        {
            var dbsociete = await Context.societes.FindAsync(request.Id); // recherche par ID ! 
            if (dbsociete == null)
                return BadRequest("N'existe pas !");
            /*var societe = Nsociete.Find(h => h.Id == request.Id);
            if (societe == null)
                return BadRequest("N'existe pas !"); */
            dbsociete.Nom=request.Nom;
            dbsociete.Responsable=request.Responsable;
            dbsociete.MatriculeF=request.MatriculeF;
            dbsociete.Address=request.Address;
            await Context.SaveChangesAsync(); 
            
            return Ok(await Context.societes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Societe>>> Delete(int id)
        { //recher par ID pour supprimer les societes 
            /* var societe = Nsociete.Find(h => h.Id == id);
             if (societe == null)
                 return BadRequest("N'existe pas !");
             Nsociete.Remove(societe); */

            var dbsociete = await Context.societes.FindAsync(id); // recherche par ID ! 
            if (dbsociete == null)
                return BadRequest("N'existe pas !");
            Context.societes.Remove(dbsociete);
            await Context.SaveChangesAsync();

            //cet ligne returns le variable creer 
            return Ok(await Context.societes.ToListAsync());

        }   

    }
    //Personel Securité 
    /*public class Prs_SecController : ControllerBase
    {
        public DataContext Context { get; }


        [HttpGet] // ActionResult List for the schemas down blow
        public async Task<ActionResult<List<Prs_Sec>>> Get()
        {
            var perso = new List<Prs_Sec>
            {
                new Prs_Sec
                {
                    CartID = 123456789,
                    Nom = "Abas",
                    Prenom = "salah"
                }
            };
            return Ok(perso);
        }
    }*/ 
}
