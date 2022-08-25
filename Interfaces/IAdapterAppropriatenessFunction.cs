// Copyright © Rafael Pérez 2022.
// rperezrosario@outlook.com.
namespace AdaptiveComputingFramework.Interfaces
{
  public interface IAdapterAppropriatenessFunction
  {
    void ComputeAppropriateness(ref IAdapter Adapter);
    void ComputeAppropriateness(ref IAdapterGroup Adapter);
  }
}