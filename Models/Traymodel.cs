﻿



using System.ComponentModel.DataAnnotations;

namespace Tray.Models;

public class TrayModel
{
    public int Id { get; set; }
    public string? ModelName { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }

    public string? Material { get; set; }

    public string? Shape { get; set; }

    public string? Pattern { get; set; }

    public string? Theme { get; set; }



}