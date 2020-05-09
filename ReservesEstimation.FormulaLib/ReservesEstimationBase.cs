using System;

namespace ReservesEstimation.FormulaLib
{
    public abstract class ReservesEstimationBase
    {
        public enum DriveMechanism
        {
            SolutionGas,
            Expansion,
            GasCap,
            WaterBottom,
            WaterEdge,
            Gravity
        }

        public abstract float GetOriginalOilInPlace();
        public abstract float GetOriginalGasInPlace();
        public abstract float GetRecoverableReserves(DriveMechanism drive = DriveMechanism.WaterBottom);
    }
}
