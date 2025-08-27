// Controllers/EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.Threading.Tasks;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _repo;
    public EmployeesController(IEmployeeRepository repo) => _repo = repo;

    // List page (optional but handy)
    public async Task<IActionResult> Index()
    {
        var list = await _repo.GetAllAsync();
        return View(list);
    }

    // Details page (shows employee + Download button)
    public async Task<IActionResult> Details(int id = 1)
    {
        var emp = await _repo.GetAsync(id);
        if (emp == null) return NotFound();
        return View(emp);
    }

    // Generates the PDF and returns it as a file download
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
            CustomSwitches = "--enable-local-file-access" // allow local CSS if needed
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

    // This ensures a raw PDF file stream is returned (not HTML)
    var pdfBytes = await pdf.BuildFile(ControllerContext);
    return File(pdfBytes, "application/pdf", "AllEmployees.pdf");
}



}
