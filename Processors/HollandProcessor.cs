// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.

using System;
using System.Collections.Generic;
using System.Linq;
using AdaptiveComputingFramework.Interfaces;

namespace AdaptiveComputingFramework.Processors
{
  public class HollandProcessor : IAdapterProcessor
  {
    public List<IAdapterGroup> AdapterGroup { get; set; }
    public IAdapterGroup TopAdapterGroup { get; set;}
    public bool Log { get; set; }
    public List<IAdapterGroup> Seed { get; set; }

    public HollandProcessor(bool Log = false)
    {
      AdapterGroup = new List<IAdapterGroup>();
      this.Log = Log;
    }

    public void ProcessAdapterGroups(int NumberOfIterations, int VariationProbabilityPercentage,
      int MaxProcessedAdapterGroupCount)
    {
      // An implementation of John Holland's genetic algorithm.
      // https://www.cc.gatech.edu/~turk/bio_sim/articles/genetic_algorithm.pdf (Retrieved 10/17/2018.)

      int i = 0;
      List<IAdapterGroup> processedAdapterGroup = new List<IAdapterGroup>();
      Random prng = new Random();

      // For statistical purposes (if DEBUG == true).
      DateTime iterationStart = DateTime.MinValue;
      TimeSpan elapsedTime = TimeSpan.MinValue;

      // Over a set amount of times:
      for (; i < NumberOfIterations; i++)
      {
        if (Log)
        {
          // Stats: Record iteration start time.
          #pragma warning disable CS0162 // Unreachable code detected.
          iterationStart = DateTime.Now;
          #pragma warning restore CS0162 // Unreachable code detected.
        }

        // Step 1: Combine adapters.
        processedAdapterGroup.Clear();
        foreach (IAdapterGroup adapterGroupA in AdapterGroup.ToList())
          foreach (IAdapterGroup adapterGroupB in AdapterGroup.ToList())
            if (adapterGroupA != adapterGroupB)
              processedAdapterGroup.Add(adapterGroupA.Combine(adapterGroupB));

        // Step 2: Insert variation according to set probability.
        foreach (IAdapterGroup aProcessedAdapterGroup in processedAdapterGroup)
          if (prng.Next(1, 100) <= VariationProbabilityPercentage)
            aProcessedAdapterGroup.Variate();
        // TODO: Implement variation using Double data structure.

        // Step 3: Compute group appropriateness.
        foreach (IAdapterGroup aProcessedAdapterGroup in processedAdapterGroup)
          aProcessedAdapterGroup.ComputeGroupAppropriateness();

        // Step 4: Sort processed adapters by appropriateness.
        processedAdapterGroup = processedAdapterGroup.OrderByDescending(
          x => x.AdapterGroupAppropriateness).ToList();

        // Step 5: Keep top adapter groups according to defined maxima.
        if (processedAdapterGroup.Count > MaxProcessedAdapterGroupCount)
          processedAdapterGroup.RemoveRange(MaxProcessedAdapterGroupCount,
            Math.Abs(processedAdapterGroup.Count - MaxProcessedAdapterGroupCount));

        // Step 6: Substitute adapter groups with processed adapter groups.
        AdapterGroup.Clear();
        foreach (IAdapterGroup aProcessedAdapterGroup in processedAdapterGroup)
          AdapterGroup.Add(aProcessedAdapterGroup);
        // TODO: Save iteration data to relational database.
        if (TopAdapterGroup == null || processedAdapterGroup[0].AdapterGroupAppropriateness >
          TopAdapterGroup.AdapterGroupAppropriateness)
          TopAdapterGroup = processedAdapterGroup[0];
        
        if (Log)
        {
          // Stats: Calculate and print iteration statistics to console.
          #pragma warning disable CS0162 // Unreachable code detected.
          elapsedTime = DateTime.Now.Subtract(iterationStart);
          #pragma warning restore CS0162 // Unreachable code detected.
          Console.WriteLine("IT\t" + (i + 1).ToString() + "\tPT\t" +
            elapsedTime.Milliseconds.ToString() + "\tms\tCFM\t" +
            AdapterGroup[0].AdapterGroupAppropriateness.ToString() +
            "\tTCFM\t" + TopAdapterGroup.AdapterGroupAppropriateness);
        }
      }
    }
  }
}