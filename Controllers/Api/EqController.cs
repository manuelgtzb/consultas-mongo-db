using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]

public class EqControlller : Controller {
 [HttpGet("listar-agencias")]

 public IActionResult ListarAgencias(){
   

      MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
      var db = client.GetDatabase("Inmuebles");
      var collection = db.GetCollection<Inmueble>("RentasVentas");

      var filtro = Builders<Inmueble>.Filter.Eq(x => x.Agencia, "Torres Realty");
      var lista = collection.Find(filtro).ToList();
   
       return Ok(lista);

    }

 }
