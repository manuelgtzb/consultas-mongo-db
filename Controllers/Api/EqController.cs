using Microsoft.AspNetCore.Mvc;
using.MongoDb.Driver;
[ApiController]
[Route("api/eq")]

public class EqControlller : Controller {
 [HttpGet("listar-agencias")]
 public IActionResult ListarAgencias(){
    return Ok();

 }
}