// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaptiveComputingFramework.Interfaces;

namespace AdaptiveComputingFramework.Processors
{
  class AnnealingProcessor : IAdapterProcessor
  {
    public List<IAdapterGroup> AdapterGroup { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IAdapterGroup TopAdapterGroup { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Log { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public AnnealingProcessor (bool Log = false)
    {
      AdapterGroup = new List<IAdapterGroup>();
      this.Log = Log;
    }

    public void ProcessAdapterGroups(int NumberOfIterations, int VariationProbabilityPercentage, int MaxProcessedAdapterGroupCount)
    {
      throw new NotImplementedException();
    }
  }
}
