using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private const string DefaultMode = "Full";
    private const string HalfMode = "Half";
    private const string EnergyMode = "Energy";
    private const double HalfModeConst = 0.5;
    private const double EnergyModeConst = 0.2;
    
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory harvesterFactory;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory harvesterFactory)
    {
        this.harvesters = new List<IHarvester>();
        this.energyRepository = energyRepository;
        this.harvesterFactory = harvesterFactory;
        this.mode = DefaultMode;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (IHarvester harvester in this.harvesters)
        {
            if (this.mode == DefaultMode)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == HalfMode)
            {
                neededEnergy += harvester.EnergyRequirement * HalfModeConst;
            }
            else if (this.mode == EnergyMode)
            {
                neededEnergy += harvester.EnergyRequirement * EnergyModeConst;
            }
        }

        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (IHarvester harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        if (this.mode == EnergyMode)
        {
            minedOres *= EnergyModeConst;
        }
        else if (this.mode == HalfMode)
        {
            minedOres *= HalfModeConst;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        IList<IHarvester> reminder = new List<IHarvester>();

        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception e)
            {
                reminder.Add(harvester);
            }
        }

        foreach (IHarvester entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ChangeMode, mode);
    }
}