// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.
using System.Collections.Generic;

namespace AdaptiveComputingFramework.Interfaces
{
  public interface IAdapterProcessor
  {
    List<IAdapterGroup> AdapterGroup { get; set; }
    IAdapterGroup TopAdapterGroup { get; set; }
    bool Log { get; set; }

    void ProcessAdapterGroups(int NumberOfIterations, int VariationProbabilityPercentage, 
      int MaxProcessedAdapterGroupCount);
  }
}