using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller {
    [HttpGet("agencia-perez")]
    public IActionResult AgenciaPerez() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Eq(x => x.Agencia, "Inmobiliaria Pérez");
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("solo-terrenos")]
    public IActionResult SoloTerrenos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("casas-en-renta")]
    public IActionResult CasasEnRenta() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroOperacion = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Renta");
        var filtro = Builders<Inmueble>.Filter.And(filtroTipo, filtroOperacion);

        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("tienen-patio-false")]
    public IActionResult TienenPatioFalse() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Eq(x => x.TienePatio, false);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("agentes-lopez")]
    public IActionResult AgentesLopez() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Si el apellido está al final del nombre del agente
        var filtro = Builders<Inmueble>.Filter.Regex(x => x.NombreAgente, new MongoDB.Bson.BsonRegularExpression("López$", "i"));
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}
