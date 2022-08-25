// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.
using AdaptiveComputingFramework.Interfaces;

namespace AdaptiveComputingFramework.Interfaces
{
  public interface IAdapter
  {
    decimal Appropriateness { get; set; }
    IVariationParameter VariationParameter { get; set; }

    void Variate(IAdapterGroup AdapterGroup);
  }
}
