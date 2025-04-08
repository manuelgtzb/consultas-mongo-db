using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/in")]
public class InController : Controller {
    [HttpGet("solo-casas")]
    public IActionResult SoloCasas() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.In(x => x.Tipo, new[] { "Casa" });
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("solo-rentas")]
    public IActionResult SoloRentas() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.In(x => x.Operacion, new[] { "Renta" });
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("agencia-garcia-propiedades")]
    public IActionResult AgenciaGarcia() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.In(x => x.Agencia, new[] { "García Propiedades" });
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("datos-true")]
    public IActionResult DatosTrue() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.In(x => x.TienePatio, new[] { true });
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("precio-exacto-4372608")]
    public IActionResult PrecioExacto4372608() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.In(x => x.Costo, new[] { 4372608 });
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}
