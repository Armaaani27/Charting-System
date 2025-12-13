using Library.ChartingSystem.Utilities;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Library.ChartingSystem.Models;
using System.Collections.ObjectModel;

//using System.Reflection.Metadata;

namespace Library.ChartingSystem.Services;

public class PhysicianServiceProxy
{
    public ObservableCollection<Physician?> Physicians { get; } = new ObservableCollection<Physician?>();

    private static PhysicianServiceProxy? instance;
    private static object instanceLock = new object();

    public static PhysicianServiceProxy Current
    {
        get
        {
            lock (instanceLock)
            {
                instance ??= new PhysicianServiceProxy();
            }
            return instance;
        }
    }

    private PhysicianServiceProxy()
    {
        RefreshFromApi().Wait();
    }

    public async Task RefreshFromApi()
    {
        var response = await new WebRequestHandler().Get("/Physician");
        var list = JsonConvert.DeserializeObject<List<Physician?>>(response) ?? new List<Physician?>();

        Physicians.Clear();
        foreach (var p in list)
            Physicians.Add(p);
    }

    public async Task<Physician?> AddOrUpdate(Physician? physician)
    {
        if (physician == null)
            return null;

        var payload = await new WebRequestHandler().Post("/Physician", physician);
        var saved = JsonConvert.DeserializeObject<Physician>(payload);

        await RefreshFromApi();

        return saved;
    }

    public async Task Delete(Physician physician)
    {
        await new WebRequestHandler().Delete($"/Physician/{physician.Id}");
        await RefreshFromApi();
    }
}