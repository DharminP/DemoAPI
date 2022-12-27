using System.Text.Json;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DemoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private iFormulaRepository _FormulaRepository;
    private iFormulaItemRepository _FormulaItemRepository;

    public DemoController(iFormulaRepository formulaRepository, iFormulaItemRepository FormulaItemRepository)
    {
        _FormulaRepository = formulaRepository;
        _FormulaItemRepository = FormulaItemRepository;
    }
    [HttpGet]
    public string _GetAllFormula()
    {
        return JsonSerializer.Serialize(_FormulaRepository.GetAllFormula<FormulaModel>("POCDB", "col_formula"));
    }
    [HttpPost]
    public async Task _CreateNewFormula(FormulaModel _Formula)
    {
        await _FormulaRepository.AddNewFormula<FormulaModel>("POCDB", "col_formula", _Formula);
    }
    [HttpGet("{f_id:int}")]
    public string _GetFormulaById(int f_id)
    {
        var filter = Builders<FormulaModel>.Filter.Eq("f_id", f_id);
        return JsonSerializer.Serialize(_FormulaRepository.GetFilteredFormula<FormulaModel>("POCDB", "col_formula", filter));
    }
    [HttpDelete("{f_id:int}")]
    public string _DeleteFormula(int f_id)
    {
        var filter = Builders<FormulaModel>.Filter.Eq("f_id", f_id);
        var result = _FormulaRepository.DeleteFormula<FormulaModel>("POCDB", "col_formula", filter);
        if (result == true)
        {
            return JsonSerializer.Serialize(_FormulaRepository.GetAllFormula<FormulaModel>("POCDB", "col_formula"));
        }
        return string.Empty;
    }
    [HttpPut]
    public async Task _UpdateFormula(FormulaModel _Formula)
    {
        var filter = Builders<FormulaModel>.Filter.Eq("f_id", _Formula.f_id);
        var _ToUpdate = Builders<FormulaModel>.Update
            .Set(p => p.f_item, _Formula.f_item)
            .Set(p => p.f_Shade, _Formula.f_Shade);
        await _FormulaRepository.UpdateFormula<FormulaModel>("POCDB", "col_formula", filter, _ToUpdate);
    }
    [HttpGet("GetAllFormulaItem")]
    public string _GetAllFormulaItem()
    {
        return JsonSerializer.Serialize(_FormulaItemRepository.GetAllFormula_Item<FormulaItemModel>("POCDB", "col_formula_item"));
    }
     [HttpPost("CreateNewFormulaItem")]
    public async Task _CreateNewFormulaItem(FormulaItemModel _FormulaItem)
    {
        await _FormulaItemRepository.AddNewFormula_Item<FormulaItemModel>("POCDB", "col_formula_item", _FormulaItem);
    }
     [HttpPut("UpdateFormulaItem")]
    public async Task _UpdateFormulaItem(FormulaItemModel _FormulaItem)
    {
        var filter = Builders<FormulaItemModel>.Filter.Eq("fi_id", _FormulaItem.fi_id);
        var _ToUpdate = Builders<FormulaItemModel>.Update
            .Set(p => p.fi_i_id, _FormulaItem.fi_i_id)
            .Set(p => p.fi_s_id, _FormulaItem.fi_s_id);
        await _FormulaItemRepository.UpdateFormula_Item<FormulaItemModel>("POCDB", "col_formula_item", filter, _ToUpdate);
    }
     [HttpDelete("{fi_id:int}")]
    public string _DeleteFormulaItem(int fi_id)
    {
        var filter = Builders<FormulaItemModel>.Filter.Eq("fi_id", fi_id);
        var result = _FormulaItemRepository.DeleteFormula_Item<FormulaItemModel>("POCDB", "col_formula_item", filter);
        if (result == true)
        {
            return JsonSerializer.Serialize(_FormulaItemRepository.GetAllFormula_Item<FormulaItemModel>("POCDB", "col_formula_item"));
        }
        return string.Empty;
    }


}

