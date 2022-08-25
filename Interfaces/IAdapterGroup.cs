// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.
using System.Collections.Generic;

namespace AdaptiveComputingFramework.Interfaces
{
  public interface IAdapterGroup
  {
    List<IAdapter> Adapter { get; set; }
    List<IAdapterAppropriatenessFunction> AdapterAppropriatenessFunction { get; set; }
    IVariationParameter VariationParameter { get; set; }
    decimal AdapterGroupAppropriateness { get; set; }

    void ComputeGroupAppropriateness();
    IAdapterGroup Combine(IAdapterGroup AdapterGroup);
    void Variate();
  }
}
