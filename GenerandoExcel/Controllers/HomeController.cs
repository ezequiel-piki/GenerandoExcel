using ClosedXML.Excel;
using GenerandoExcel.Entidades;
using GenerandoExcel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace GenerandoExcel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<FileResult> ExportarPersonasAExcel()
        {
            var personas = await _appDbContext.Personas.ToListAsync();
            var nombreDelArchivo = $"Personas.xlsx";
            return GeneraExcel(nombreDelArchivo,personas);
        }

        private FileResult GeneraExcel(string nombreDelArchivo, IEnumerable<Persona> personas)
        {
            DataTable dataTable = new DataTable("Personas");
            
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("Nombre")
            });
            
            foreach (var persona in personas)
            {
                dataTable.Rows.Add(persona.Id, persona.Nombre);

            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dataTable);

                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nombreDelArchivo
                        );
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}