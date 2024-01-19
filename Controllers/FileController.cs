using Microsoft.AspNetCore.Mvc;

namespace TextFilesMvc;

public class FileController : Controller
{
  private readonly ILogger<FileController> _logger;

  private readonly IWebHostEnvironment _env;

  public FileController(ILogger<FileController> logger, IWebHostEnvironment env)
  {
    _logger = logger;
    _env = env;
  }

public IActionResult Index()
{
    var path = Path.Combine(_env.ContentRootPath, "TextFiles");
    var filePaths = Directory.GetFiles(path);
    ViewBag.Files = Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
    return View();
}

public IActionResult Content(string fileName)
{
    var path = Path.Combine(_env.ContentRootPath, "TextFiles", fileName);
    if (System.IO.File.Exists(path))
    {
        ViewBag.Content = System.IO.File.ReadAllText(path);
    }
    else
    {
        ViewBag.Content = "File not found.";
    }
    return View();
}
}

