using AutoMapper;
using MetaData.Entities;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models.Cliente;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Utils.Response;

//cache distribuído -> redis
namespace MVCApplication.Controllers;

public class ClienteController : Controller
{
    private readonly IMapper _mapper;

    public ClienteController(IMapper mapper)
    {
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = new DataResponse<Cliente>();
        using (var client = new HttpClient())
        {
            response = await client.GetFromJsonAsync<DataResponse<Cliente>>(@"https://localhost:7172/api/Cliente");
        }

        if (!response.HasSuccess)
        {
            ViewBag.Errors = new string[] { response.Message };
            return View();
        }

        List<ClienteQueryViewModel> data = _mapper.Map<List<ClienteQueryViewModel>>(response.Data);

        return View(data);
    }

    //o padrão é http get, se n escrever nada esse é o default
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //data annotation / attribute
    //só pode ser acessado por um post
    [HttpPost]
    [ResponseCache(VaryByHeader = "None", Duration = 60)] //pesquisar VaryByHeader, poder ser por query
    public async Task<IActionResult> Create(ClienteInsertViewModel viewModel)
    {
        var cliente = _mapper.Map<Cliente>(viewModel);

        HttpResponseMessage response;
        using (var client = new HttpClient())
        {
            response = await client.PostAsJsonAsync<Cliente>(@"https://localhost:7172/api/Cliente/Create", cliente);
        }

        if (!response.IsSuccessStatusCode)
        {
            var responseErrors = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
            ViewBag.Errors = responseErrors.ToArray();
            return View();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
        {
            return RedirectToAction("Index");
        }

        SingleResponse<Cliente> response;
        using (var client = new HttpClient())
        {
            response = await client.GetFromJsonAsync<SingleResponse<Cliente>>(@"https://localhost:7172/api/Cliente/" + id.Value);
        }

        if (!response.HasSuccess)
        {
            ViewBag.Errors = response.Errors.ToArray();
        }

        Cliente cliente = response.Item;
        ClienteUpdateViewModel viewModel = _mapper.Map<ClienteUpdateViewModel>(cliente);
        return View(viewModel);
    }

    //ateção aos hidden fields, pq é possível alterar pelo inspetor
    [HttpPost]
    public async Task<IActionResult> Edit(ClienteUpdateViewModel viewModel)
    {
        var cliente = _mapper.Map<Cliente>(viewModel);

        HttpResponseMessage response;
        using (var client = new HttpClient())
        {
            response = await client.PutAsJsonAsync(@"https://localhost:7172/api/Cliente/Edit", cliente);
        }

        if (!response.IsSuccessStatusCode)
        {
            var responseErrors = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
            ViewBag.Errors = responseErrors.ToArray();
            return View(viewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
        {
            return RedirectToAction("Index");
        }

        SingleResponse<Cliente> response;
        using (var client = new HttpClient())
        {
            response = await client.GetFromJsonAsync<SingleResponse<Cliente>>(@"https://localhost:7172/api/Cliente/" + id.Value);
        }

        if (!response.HasSuccess)
        {
            ViewBag.Errors = response.Errors.ToArray();
        }

        Cliente cliente = response.Item;
        ClienteQueryViewModel viewModel = _mapper.Map<ClienteQueryViewModel>(cliente);
        return View(viewModel);
    }
}

//class CustomAutoMapper<T, W> where W : new()
//{
//    public static W MapTo(T item)
//    {
//        W w = new W();

//        foreach (var property in typeof(T).GetProperties())
//        {
//            PropertyInfo? propertyTarget = typeof(W).GetProperty(property.Name);
//            if (propertyTarget != null)
//            {
//                propertyTarget.SetValue(w, property.GetValue(item));
//            }
//        }

//        return w;
//    }
//}
