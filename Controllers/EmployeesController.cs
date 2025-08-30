
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.Threading.Tasks;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _repo;
    public EmployeesController(IEmployeeRepository repo) => _repo = repo;

    
    public async Task<IActionResult> Index()
    {
        var list = await _repo.GetAllAsync();
        return View(list);
    }

    
    public async Task<IActionResult> Details(int id = 1)
    {
        var emp = await _repo.GetAsync(id);
        if (emp == null) return NotFound();
        return View(emp);
    }

    
    [HttpGet]
    public async Task<IActionResult> DownloadPdf(int id)
    {
        var emp = await _repo.GetAsync(id);
        if (emp == null) return NotFound();

        var pdf = new ViewAsPdf("DetailsPdf", emp)
        {
            FileName = $"Employee_{emp.Id}.pdf",
            PageSize = Size.A4,
            PageOrientation = Orientation.Portrait,
            CustomSwitches = "--enable-local-file-access"
        };

        return pdf;
    }
[HttpGet]
public async Task<IActionResult> DownloadAllPdf()
{
    var employees = await _repo.GetAllAsync();

    var pdf = new ViewAsPdf("AllEmployeesPdf", employees)
    {
        FileName = "AllEmployees.pdf",
        PageSize = Size.A4,
        PageOrientation = Orientation.Landscape,
        CustomSwitches = "--enable-local-file-access"
    };

    
    var pdfBytes = await pdf.BuildFile(ControllerContext);
    return File(pdfBytes, "application/pdf", "AllEmployees.pdf");
}



}

